using Microsoft.AspNetCore.Http;
using MyBlog.Models;
using MyBlog.Services.DtoModels;

namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, bool isPersistent, HttpContext httpContext);

        void SignOut(HttpContext httpContext);
        StatusModel SingUp(User user);
    }
}
