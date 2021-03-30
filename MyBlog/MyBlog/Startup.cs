using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog
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
            services.AddDbContext<MyBlogDbContext>(
                x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyBlog;Trusted_Connection=True;")
                );


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                    options.LoginPath = "/Auth/SignIn";
                    options.AccessDeniedPath = "/Auth/AccessDenied";
                }
                );

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdministrator", policy =>
                {
                    policy.RequireClaim("IsAdministrator", "True");
                });
            });

            services.AddControllersWithViews();
            services.AddTransient<IEventsService, EventsService>();
            services.AddTransient<IRegionsService, RegionsService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserServices, UserServices>();

            services.AddTransient<IEventsRepository, EventsRepository>();
            services.AddTransient<IRegionsRepository, RegionsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Events}/{action=Overview}/{id?}");
            });
        }
    }
}
