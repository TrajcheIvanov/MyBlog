using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
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
    }
}
