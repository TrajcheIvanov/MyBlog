using Microsoft.AspNetCore.Http;
using MyBlog.Services.DtoModels;


namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, HttpContext httpContext);
    }
}
