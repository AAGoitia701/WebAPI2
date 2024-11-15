using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Custom;
using WebAPI2.Mappers;
using WebAPI2.Models;
using WebAPI2.Models.DTOs;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous] //because it's just to register and login
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly DbTestContext _context;
        private readonly IUtilities _utilities;

        public AccessController(DbTestContext context, IUtilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> RegisterUser(UserDTO userdto)
        {
            var userModel = userdto.FromDtoToUser();
            if (userModel == null) 
            {
                return BadRequest();
            } 

            await _context.MainUsers.AddAsync(userModel);

            await _context.SaveChangesAsync();

            if(userModel.IdUser != 0)
            {
                return StatusCode(StatusCodes.Status201Created, new {isSuccess = true});
            }
            else
            {
                return StatusCode(StatusCodes.Status201Created, new { isSuccess = false });
            }

            return Ok(userModel);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> LoginUser(LoginDTO logindto)
        {
            var modelUser = logindto.FromLoginDtoToMainUser();

            var userdb = _context.MainUsers.FirstOrDefault(r => r.Email.Equals(logindto.Email) && r.Password.Equals(logindto.Password));
            if (userdb == null) {
                return StatusCode(StatusCodes.Status404NotFound, new {isSuccess = false, token=""});

            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilities.GenerateToken(userdb) });
            }





        }
    }
}
