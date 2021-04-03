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

        public StatusModel ToggleAdmin(int id)
        {
            var response = new StatusModel();

            var user = _userRepository.GetById(id);

            if (user.IsAdministrator)
            {
                user.IsAdministrator = false;
                Udpate(user);
            }
            else
            {
                user.IsAdministrator = true;
                Udpate(user);
            }

            return response;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetDetails(string userId)
        {
            return _userRepository.GetById(int.Parse(userId));
        }

        public StatusModel Udpate(User user)
        {
            var response = new StatusModel();
            var updateUser = _userRepository.GetById(user.Id);

            if (updateUser != null)
            {

                updateUser.Email = user.Email;
                _userRepository.Update(updateUser);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }

            return response;
        }

        public StatusModel Delete(int Id)
        {
            var response = new StatusModel();
            var userToDelete = _userRepository.GetById(Id);

            if (userToDelete != null)
            {
                _userRepository.Delete(userToDelete);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }

            return response;
        }
    }
}
