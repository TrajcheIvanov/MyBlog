using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsLikeRepository : BaseRepository<EventLike> , IEventsLikeRepository
    {

        public EventsLikeRepository(MyBlogDbContext context) : base(context)
        {

        }

        public EventLike Get(int eventId, int userId)
        {
            return _context.EventLikes.FirstOrDefault(x => x.EventId == eventId && x.UserId == userId);
        }
    }
}
