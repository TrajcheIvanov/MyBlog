using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IEventsRepository
    {
        List<Event> GetAll();

        List<Event> GetByName(string name);
        Event GetById(int id);

        void Add(Event even);
        
    }
}
