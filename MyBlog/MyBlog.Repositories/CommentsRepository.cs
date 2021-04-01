using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories
{
    public class CommentsRepository : BaseRepository<Comment> , ICommentsRepository
    {
        public CommentsRepository(MyBlogDbContext context) : base (context)
        {

        }
    }
}
