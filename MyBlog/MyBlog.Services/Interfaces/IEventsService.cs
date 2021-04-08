using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IEventsService
    {
        List<Event> GetAllEvents();

        List<Event> GetEventByName(string name);
        Event GetEventById(int id);

        Event GetEventDetails(int Id);
        void CreateEvent(Event even);

        void Delete(int Id);

        void Update(Event even);
        List<Event> GetMostRecentEvents(int count);

        List<Event> GetTopEvents(int count);
    }
}
