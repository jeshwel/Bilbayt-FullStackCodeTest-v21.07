using FullStackCodeTest.BLL.DTOs;
using System;

namespace FullStackCodeTest.BLL.Contracts
{
    public interface IUserService
    {
        bool Register(UserDTO User);
        string Login(string UserName, string Password);
        UserDTO Get(Guid Id);
    }
}