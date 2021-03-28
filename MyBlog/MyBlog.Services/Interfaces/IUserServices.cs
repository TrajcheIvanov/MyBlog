using MyBlog.Models;
using MyBlog.Services.DtoModels;

namespace MyBlog.Services.Interfaces
{
    public interface IUserServices
    {
        User GetDetails(string userId);

        StatusModel Update(User user);
    }
}
