using MyBlog.Models;
using MyBlog.Services.DtoModels;
using System.Collections.Generic;

namespace MyBlog.Services.Interfaces
{
    public interface IUserServices
    {
        User GetDetails(string userId);

        StatusModel Udpate(User user);

        List<User> GetAllUsers();

        StatusModel ToggleAdmin(int id);

        StatusModel Delete(int Id);
    }
}
