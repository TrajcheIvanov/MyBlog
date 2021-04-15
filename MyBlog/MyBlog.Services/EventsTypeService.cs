using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class EventsTypeService : IEventsTypeService
    {
        private IEventsTypeRepository _eventsTypeRepository;
        public EventsTypeService(IEventsTypeRepository eventsTypeRepository)
        {
            _eventsTypeRepository = eventsTypeRepository;
        }

        public bool CheckIfExists(int eventTypeId)
        {
            var eventType = _eventsTypeRepository.GetById(eventTypeId);

            return eventType != null;
        }

        public List<EventType> GetAll()
        {
            return _eventsTypeRepository.GetAll();
        }
    }
}
