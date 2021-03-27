using MyBlog.Models;


namespace MyBlog.Services.Interfaces
{
    public interface IUserServices
    {
        User GetDetails(string userId);
    }
}
