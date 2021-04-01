﻿using MyBlog.Models;
using MyBlog.ViewModels;
using System.Collections.Generic;

namespace MyBlog.Mappings
{
    public static class DomainModelExtensions
    {


        public static EventOverviewModel ToOverviewModel(this Event even)
        {
            return new EventOverviewModel()
            {
                Id = even.Id,
                Name = even.Name,
                Date = even.Date,
                ImgUrl = even.ImgUrl,
            };
        }

        public static EventManageEventsModel ToManageEventsModel(this Event even)
        {
            return new EventManageEventsModel()
            {
                Id = even.Id,
                Name = even.Name,
                Date = even.Date,
                Location = even.Location,
            };
        }


        public static EventMoreInfoModel ToMoreInfoModel(this Event even)
        {
            return new EventMoreInfoModel()
            {
                
                Name = even.Name,
                Location = even.Location,
                Date = even.Date,
                Description = even.Description,
                OrganizedBy = even.OrganizedBy,
                ImgUrl = even.ImgUrl,
                DateCreated = even.DateCreated,
            };
        }

        public static EventUpdateModel ToUpdateModel (this Event even)
        {
            return new EventUpdateModel()
            {
                Id = even.Id,
                Name = even.Name,
                Location = even.Location,
                Date = even.Date,
                Description = even.Description,
                OrganizedBy = even.OrganizedBy,
                ImgUrl = even.ImgUrl,
            };
        }

        public static UsersDetailsModel ToDetailsModel(this User user)
        {
            return new UsersDetailsModel()
            {
                Username = user.Username,
                Email = user.Email,
            };
        }

        public static UserUpdateModel ToUpdateModel(this User user)
        {
            return new UserUpdateModel()
            {
                Username = user.Username,
                Email = user.Email,

            };
        }

        public static List<ManageUserModel> ToManageUserModels(this List<User> users)
        {
            var manageUsers = new List<ManageUserModel>();

            foreach (var user in users)
            {
                var newManageUserModel = new ManageUserModel();
                newManageUserModel.Id = user.Id;
                newManageUserModel.Username = user.Username;
                newManageUserModel.IsAdministrator = user.IsAdministrator;

                manageUsers.Add(newManageUserModel);
            }

            return manageUsers;
        }
    }
}