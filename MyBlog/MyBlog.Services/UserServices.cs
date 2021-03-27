using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class UserServices : IUserServices
    {
        private IUsersRepository _userRepository;
        public UserServices(IUsersRepository useRepository)
        {
            _userRepository = useRepository;
        }

        public User GetDetails(string userId)
        {
            return _userRepository.GetById(int.Parse(userId));
        }
    }
}
