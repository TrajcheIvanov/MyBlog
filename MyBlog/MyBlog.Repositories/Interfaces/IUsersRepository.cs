using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);

        User GetById(int userId);

        void Update(User user);

        bool CheckIfExists(string username, string email);

        void Add(User user);

        List<User> GetAll();

        void Remove(User user);
    }
}
