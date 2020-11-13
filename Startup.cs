using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfficerEngagement.Helpers;
using OfficerEngagement.Models;
using OfficerEngagement.Repository;
using OfficerEngagement.Service;

namespace OfficerEngagement
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
            services.AddControllersWithViews();
            services.AddDbContext<EngagementContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("EngagConnection")));
            services.AddIdentity<AppilicationUser, IdentityRole>().AddEntityFrameworkStores<EngagementContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            } );

            services.AddScoped<IUserClaimsPrincipalFactory<AppilicationUser>, ApplicationUserClaimsPrincipalFactory>();
            services.AddScoped<IUserService, UserService>();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/login";
            });

            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
