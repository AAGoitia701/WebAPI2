using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAPI2.Models;

namespace WebAPI2.Custom
{
    public class Utilities : IUtilities
    {
        private readonly IConfiguration _configuration;
        public Utilities(IConfiguration config)
        {
            _configuration = config;
        }
        //encrypting password
        public string EncryptingSHA256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                //compute hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                //transform byte to string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }

                return sb.ToString();
            }

        }

        public string GenerateToken(MainUser userModel)
        {
            //create user info
            var userClaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.IdUser.ToString()),
                new Claim(ClaimTypes.Email, userModel.Email)
            };

            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            //create sign in credentials
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: userClaim,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
