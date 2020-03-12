using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Steunijos.Web.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Steunijos.Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Steunijos.Web.FrameworkExtensions;
using Microsoft.AspNetCore.HttpOverrides;
using Steunijos.Web.SteunijosServices;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Steunijos.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SteunijosContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<SteunijosContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddSteUserOptions();

            services.AddAuthentication()
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                    Configuration.GetSection("AuthGoogle");

                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });

            services.AddTransient<IGoogleDriveService, GoogleDriveService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            var cachePeriod = env.IsDevelopment() ? "600" : "604800";

            var path = Path.Combine(env.WebRootPath, "Uploads");
            var paperPath = Path.Combine(env.WebRootPath, "Papers");
            var journalPath = Path.Combine(path, "Journals");
            var depositSlipPath = Path.Combine(path, "BankDeposits");

            var dir = new DirectoryInfo(path);

            if (!Directory.Exists(path))
            {
                dir.Create();
            }

            if (!Directory.Exists(paperPath))
            {
                Directory.CreateDirectory(paperPath);
            }

            if (!Directory.Exists(journalPath))
            {
                Directory.CreateDirectory(journalPath);
            }

            if (!Directory.Exists(depositSlipPath))
            {
                Directory.CreateDirectory(depositSlipPath);
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    //Path.Combine(Directory.GetCurrentDirectory(), "Uploads") 
                    path
                ),
                RequestPath = "/AppUploads",
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
