using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IEventsLikeService
    {
        void Add(int eventId, int userId);
        void Remove(int eventId, int userId);
    }
}
