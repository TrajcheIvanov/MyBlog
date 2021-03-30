using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBlog.Models;
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

        public StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext)
        {
            var responese = new StatusModel();
            var user = _usersRepository.GetByUsername(username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password,user.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("IsAdministrator", user.IsAdministrator.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = isPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();

                responese.IsSuccessful = true;
            }
            else
            {
                responese.IsSuccessful = false;
                responese.Message = "Username or password is incorrect";
            }

            return responese;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SingUp(User user)
        {
            var response = new StatusModel();

            var exist = _usersRepository.CheckIfExists(user.Username, user.Email);

            if (exist)
            {
                response.IsSuccessful = false;
                response.Message = "UIser with username or email already exists";
            }
            else
            {
                var password = user.Password;
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                user.DateCreat = DateTime.Now;
                _usersRepository.Add(user);
            }

            return response;
        }
    }
}
