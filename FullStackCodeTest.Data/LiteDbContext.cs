using FullStackCodeTest.Data.Contracts;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace FullStackCodeTest.Data
{
    public class LiteDbContext : IDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IConfiguration config)
        {
            Database = new LiteDatabase(config["LiteDB:DBLocation"]);
        }
    }
}
