﻿using MyBlog.Common.Exceptions;
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
            _eventsRepository.Update(even);
        }
    }
}
