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
    }
}
