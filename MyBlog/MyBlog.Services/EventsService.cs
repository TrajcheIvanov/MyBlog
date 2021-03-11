using MyBlog.Models;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class EventsService
    {
        private EventsRepository _eventsRepository { get; set; }

        public EventsService()
        {
            _eventsRepository = new EventsRepository();
        }

        public List<Event> GetAllEvents()
        {
            return _eventsRepository.GetAll();
        }

        public Event GetEventById(int id)
        {
            return _eventsRepository.GetById(id);
        }
    }
}
