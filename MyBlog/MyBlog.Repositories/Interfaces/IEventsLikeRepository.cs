using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IEventsLikeRepository : IBaseRepository<EventLike>
    {
        EventLike Get(int eventId, int userId);
    }
}
