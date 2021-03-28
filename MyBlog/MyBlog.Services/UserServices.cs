using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.DtoModels;
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

        public StatusModel Update(User user)
        {
            var response = new StatusModel();
            var updateUser = _userRepository.GetById(user.Id);

            if (updateUser != null)
            {

                updateUser.Email = user.Email;

                _userRepository.Update(updateUser);

                response.IsSuccessful = true;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The User with id {user.Id} was not found";
            }

            return response;
        }
    }
}
