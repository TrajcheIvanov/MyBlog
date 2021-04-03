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

    
        public List<Event> GetByName(string name)
        {
            var events = _context.Events.Where(x => x.Name.Contains(name)).ToList();
            return events;
        }

        public override Event GetById(int entityId)
        {
            var even = _context.Events
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);

            return even;
        }
    }
}
