using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);

        bool CheckIfExists(string username, string email);

    }
}
