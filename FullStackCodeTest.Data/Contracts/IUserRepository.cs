using FullStackCodeTest.Data.Entities;
using System;

namespace FullStackCodeTest.Data.Contracts
{
    public interface IUserRepository
    {
        bool Save(User user);
        User Get(Guid id);
        User GetByName(string userName);
    }
}
