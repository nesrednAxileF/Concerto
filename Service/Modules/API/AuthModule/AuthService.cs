using Model.DTO;
using Model.Subdomains.AuthSubdomain;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules.API.AuthModule
{
    public interface IAuthService
    {
        Task<User> RegisterUser(User data);
        Task<User> CheckLoginData(UserLogin data);
    }
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CheckLoginData(UserLogin data)
        {
            UserDTO userDTO = await userRepository.FindByEmailAndPassword(data.Email, data.Password);
            if (userDTO == null)
                return null;
            return new User
            {
                UserID = userDTO.ID,
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth
            };
        }

        public async Task<User> RegisterUser(User data)
        {
            UserDTO userDTO = await userRepository.InsertAsync(new UserDTO
            {
                Email = data.Email,
                Password = data.Password,
                FirstName = data.FirstName,
                LastName = data.LastName,
                DateOfBirth = data.DateOfBirth
            });
            data.UserID = userDTO.ID;
            data.Password = "";
            return data;
        }
    }
}
