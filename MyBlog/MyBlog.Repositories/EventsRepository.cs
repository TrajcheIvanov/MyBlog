using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsRepository : BaseRepository<Event>, IEventsRepository
    {   
        
        public EventsRepository(MyBlogDbContext context) : base(context)
        {
        }

    

        public override Event GetById(int entityId)
        {
            var even = _context.Events
                .Include(x => x.EventType)
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);

            return even;
        }

        public List<Event> GetTopEvents(int count)
        {
            return _context.Events.OrderByDescending(x => x.Views).Take(5).ToList();
        }

        public List<Event> GetMostRecentEvents(int count)
        {
            return _context.Events.OrderByDescending(x => x.DateCreated).Take(5).ToList();
        }

        public List<Event> GetEventsWithFilters(string name)
        { 
            var query = _context.Events.Include(x => x.EventType).Include(x => x.EventLikes);

            if (name != null)
            {
                query.Where(x => x.Name.Contains(name));
            }

            var events = query.ToList();

            return events;
        }
    }
}
