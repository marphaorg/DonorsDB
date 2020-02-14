using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DonorsDBUI
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
            services.AddMvc(obj =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                obj.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.LoginPath = new PathString("/SignIn");
                options.AccessDeniedPath = new PathString("/Home/denied");
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminOnly", policy =>
                      policy.RequireRole("Administrator"));
                options.AddPolicy("RequireManagerOnly", policy =>
                      policy.RequireRole("Manager", "Administrator"));
                options.AddPolicy("ShouldBeUserOnly", policy =>
                     policy.RequireRole("User", "Manager", "Administrator"));
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
