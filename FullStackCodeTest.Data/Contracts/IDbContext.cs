using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullStackCodeTest.Data.Contracts
{
    public interface IDatabase<TDatabase> where TDatabase : class
    {
        TDatabase Database { get; }
    }

    public interface IDbContext: IDatabase<LiteDatabase>
    {

    }
}
