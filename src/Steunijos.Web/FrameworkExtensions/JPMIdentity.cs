using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.FrameworkExtensions
{
    public static class STEIdentity
    {

        public static IServiceCollection AddSteUserOptions(this IServiceCollection service)
        {
            service.Configure<IdentityOptions>(options =>
            {
                 options.Password.RequireDigit = false;
                 options.Password.RequiredLength = 8;
                 options.Password.RequireLowercase = true;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;


                 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMKOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
            });

            service.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            return service;
        }
    }
}
