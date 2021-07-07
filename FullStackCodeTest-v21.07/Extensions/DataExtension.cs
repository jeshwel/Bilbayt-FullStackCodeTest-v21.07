using FullStackCodeTest.Data;
using FullStackCodeTest.Data.Contracts;
using FullStackCodeTest.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCodeTest_v21_07.Extensions
{
    public static class DataExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbContext, LiteDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
