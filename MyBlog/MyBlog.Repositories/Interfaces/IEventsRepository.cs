using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IEventsRepository : IBaseRepository<Event>
    {
        
        List<Event> GetByName(string name);
        List<Event> GetMostRecentEvents(int count);

        List<Event> GetTopEvents(int count);
    }
}
