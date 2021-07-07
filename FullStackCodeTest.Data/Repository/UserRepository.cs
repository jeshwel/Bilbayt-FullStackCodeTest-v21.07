using FullStackCodeTest.Data.Contracts;
using FullStackCodeTest.Data.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackCodeTest.Data.Repository
{


    public class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;
        public UserRepository(IDbContext DbContext)
        {
            dbContext = DbContext;
        }
        public User Get(Guid id)
        {
            var col = dbContext.Database.GetCollection<User>("Users");
            return col.FindOne(x => x.Id == id);
        }
        public User GetByName(string userName)
        {
            var col = dbContext.Database.GetCollection<User>("Users");
            return col.FindOne(x => x.UserName == userName);
        }
        public bool Save(User user)
        {
            // Get a collection (or create, if doesn't exist)
            var col = dbContext.Database.GetCollection<User>("Users");
            col.Insert(user);
            // Index document using UserName property
            col.EnsureIndex(x => x.UserName);
            return true;
        }
    }
}
