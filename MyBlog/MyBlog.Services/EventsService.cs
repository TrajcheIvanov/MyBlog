using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public class EventsService : IEventsService
    {
        private IEventsRepository _eventsRepository { get; set; }

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public List<Event> GetAllEvents()
        {
            return _eventsRepository.GetAll();
        }

        public Event GetEventById(int id)
        {
            return _eventsRepository.GetById(id);
        }

        public void CreateEvent(Event even)
        {
            _eventsRepository.Add(even);
        }
    }
}
