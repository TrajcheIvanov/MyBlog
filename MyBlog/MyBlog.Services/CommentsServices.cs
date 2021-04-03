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
        public CommentsServices(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public void Add(string comment, int eventId, int userId)
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
    }
}
