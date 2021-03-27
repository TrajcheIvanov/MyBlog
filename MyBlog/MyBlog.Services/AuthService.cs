using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.DtoModels;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class AuthService : IAuthService
    {
        private IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public StatusModel SignIn(string username, string password, HttpContext httpContext)
        {
            var responese = new StatusModel();
            var user = _usersRepository.GetByUsername(username);

            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                Task.Run(() => httpContext.SignInAsync(principal)).GetAwaiter().GetResult();

                responese.IsSuccessful = true;
            }
            else
            {
                responese.IsSuccessful = false;
                responese.Message = "Username or password is incorrect";
            }

            return responese;
        }
    }
}
