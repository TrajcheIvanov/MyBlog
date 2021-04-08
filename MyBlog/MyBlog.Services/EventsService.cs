using MyBlog.Common.Exceptions;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
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

        public Event GetEventDetails(int Id)
        {
            var even = _eventsRepository.GetById(Id);

            if (even == null)
            {
                return even;
            }

            even.Views++;
            _eventsRepository.Update(even);
            return even;
        }

        public void CreateEvent(Event even)
        {
            even.DateCreated = DateTime.Now;
            _eventsRepository.Add(even);
        }

        public List<Event> GetEventByName(string name)
        {

            if (name == null)
            {
                return _eventsRepository.GetAll();
            } else
            {
                return _eventsRepository.GetByName(name);
            }
           
        }

        public void Delete(int Id)
        {
            var even = _eventsRepository.GetById(Id);

            if (even == null)
            {
                throw new NotFoundException($"The Event with id {Id} was not found");
            }
            else
            {
                _eventsRepository.Delete(even);
            }
        }

        public void Update(Event even)
        {
            var EventForUpdate = _eventsRepository.GetById(even.Id);

            if (EventForUpdate != null)
            {
               
                EventForUpdate.Date = even.Date;
                EventForUpdate.Description = even.Description;
                EventForUpdate.ImgUrl = even.ImgUrl;
                EventForUpdate.Location = even.Location;
                EventForUpdate.Name = even.Name;
                EventForUpdate.OrganizedBy = even.OrganizedBy;
                EventForUpdate.DateModified = DateTime.Now;

                _eventsRepository.Update(EventForUpdate);
            }
            else
            {
                throw new NotFoundException($"The Event with id {even.Id} was not found");
            }
            
        }

        public List<Event> GetMostRecentEvents(int count)
        {
            return _eventsRepository.GetMostRecentEvents(count);
        }

        public List<Event> GetTopEvents(int count)
        {
            return _eventsRepository.GetTopEvents(count);
        }
    }
}
