﻿using MyBlog.Models;
using MyBlog.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                EventType = even.EventType.Name,
                EventLikes = even.EventLikes.Select(x => x.ToEventLikeModel()).ToList()
            };
        }

        public static EventLikeModel ToEventLikeModel(this EventLike eventLike)
        {
            return new EventLikeModel()
            {
                Id =eventLike.Id,
                EventId = eventLike.EventId,
                UserId = eventLike.UserId
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

        public static EventTypeModel ToEventTypeModel(this EventType evenType)
        {
            return new EventTypeModel()
            {
                Id = evenType.Id,
                Name = evenType.Name,
            };
        }

        public static EventMoreInfoModel ToMoreInfoModel(this Event even)
        {
            return new EventMoreInfoModel()
            {
                Id = even.Id,
                Name = even.Name,
                Location = even.Location,
                Date = even.Date,
                Description = even.Description,
                OrganizedBy = even.OrganizedBy,
                ImgUrl = even.ImgUrl,
                DateCreated = even.DateCreated,
                EventType = even.EventType.Name,
                Comments = even.Comments.Select(x => x.ToCommentModel()).ToList()
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
                EventTypeId = even.EventTypeId
            };
        }

        public static EventSidebarModel ToRecipeSidebarModel(this Event even)
        {
            return new EventSidebarModel()
            {
                Id = even.Id,
                Name = even.Name,
                Views = even.Views,
                DateCreated = even.DateCreated,
            };

        }

    

        public static UsersDetailsModel ToDetailsModel(this User user)
        {
            return new UsersDetailsModel()
            {
                Username = user.Username,
                Email = user.Email,
                Comments = user.Comments.Select(x=> x.ToCommentUSerModel()).ToList()
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

        public static EventCommentModel ToCommentModel(this Comment comment)
        {
            return new EventCommentModel()
            {
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username,
                Id = comment.Id,
                UserId = comment.User.Id
            };
        }

        public static CommentUserDetailsModel ToCommentUSerModel(this Comment comment)
        {
            return new CommentUserDetailsModel()
            {

                Message = comment.Message,
                DateCreated = comment.DateCreated,
                EventId = comment.EventId,
                UserId = comment.UserId,
                EventName = comment.Event.Name
            };
        }
    }
}
