using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.DtoModels;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class CommentsServices : ICommentsService
    {
        private ICommentsRepository _commentsRepository;

        private IEventsService _eventsService;
        public CommentsServices(ICommentsRepository commentsRepository, IEventsService eventsService)
        {
            _commentsRepository = commentsRepository;
            _eventsService = eventsService;
        }

        public StatusModel Add(string comment, int eventId, int userId)
        {
            var response = new StatusModel();
            var even = _eventsService.GetEventById(eventId);

            if (even != null)
            {
                var newComment = new Comment()
                {
                    Message = comment,
                    DateCreated = DateTime.Now,
                    EventId = eventId,
                    UserId = userId
                };

                _commentsRepository.Add(newComment);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The event with Id {eventId} was not found";
            }
            

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();


            var commentToDelete = _commentsRepository.GetById(id);

            if (commentToDelete != null)
            {
                _commentsRepository.Delete(commentToDelete);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Comment was not found";
            }

            return response;
        }

        public StatusModel Update(int id, string comment)
        {
            var response = new StatusModel();

            var commentToUpdate = _commentsRepository.GetById(id);

            if (commentToUpdate != null)
            {
                commentToUpdate.Message = comment;
                _commentsRepository.Update(commentToUpdate);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Comment was not found";
            }

            return response;
        }
    }
}
