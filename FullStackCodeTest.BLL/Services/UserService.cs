using AutoMapper;
using FullStackCodeTest.BLL.Contracts;
using FullStackCodeTest.BLL.DTOs;
using FullStackCodeTest.Data.Contracts;
using FullStackCodeTest.Data.Entities;
using System;

namespace FullStackCodeTest.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthenticationService authService;
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserService(IAuthenticationService AuthService, IUserRepository UserRepository, IMapper Mapper)
        {
            authService = AuthService;
            repository = UserRepository;
            mapper = Mapper;
        }
        public UserDTO Get(Guid Id)
        {
            var user = mapper.Map<UserDTO>(repository.Get(Id));
            return user;
        }
        public bool Register(UserDTO user)
        {
            //Note: Uniqueness for email of each user is not verified as this is a demo project.
            var userName = repository.GetByName(user.UserName);
            if (userName != null)
                throw new Exception("UserName already exists, please try another.");
            repository.Save(mapper.Map<User>(user));
            //Send Grid email service to be called here but when I tried to create an account in SendGrid they flagged my email.
            return true;
        }
        public string Login(string UserName, string Password)
        {
            var user = repository.GetByName(UserName);
            if (user == null)
                throw new Exception("Sorry, you are not a registered user.");
            if (!(user.Password == Password))
                throw new Exception("Oops, password entered is incorrect.");
            return authService.GenerateSecurityToken(user.Id.ToString());
        }

    }
}
