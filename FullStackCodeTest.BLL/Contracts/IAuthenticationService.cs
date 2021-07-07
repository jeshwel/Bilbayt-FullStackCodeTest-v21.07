using FullStackCodeTest.BLL.DTOs;

namespace FullStackCodeTest.BLL.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateSecurityToken(string name);
    }
}