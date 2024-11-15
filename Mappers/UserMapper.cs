using WebAPI2.Models;
using WebAPI2.Models.DTOs;

namespace WebAPI2.Mappers
{
    public static class UserMapper
    {
        public static MainUser FromDtoToUser(this UserDTO userdto)
        {
            return new MainUser()
            {
                Email = userdto.Email,
                Name = userdto.Name,
                Password = userdto.Password,
            };
        }

        public static MainUser FromLoginDtoToMainUser(this LoginDTO logindto) 
        {
            return new MainUser
            {
                Email = logindto.Email,
                Password = logindto.Password,
            };
        }

    }
}
