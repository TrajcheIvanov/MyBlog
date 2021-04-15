using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsTypeRepository : BaseRepository<EventType> , IEventsTypeRepository
    {

        public EventsTypeRepository(MyBlogDbContext context) : base(context)
        {

        }
    }
}
