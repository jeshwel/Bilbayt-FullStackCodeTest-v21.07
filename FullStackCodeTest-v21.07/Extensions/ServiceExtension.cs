using FullStackCodeTest.BLL.Contracts;
using FullStackCodeTest.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackCodeTest_v21_07.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
