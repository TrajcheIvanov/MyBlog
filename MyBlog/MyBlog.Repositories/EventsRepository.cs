﻿using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsRepository : IEventsRepository
    {   
        private MyBlogDbContext _context { get; set; }

        public EventsRepository(MyBlogDbContext context)
        {
            _context = context;
        }
        public void Add(Event even)
        {
            _context.Events.Add(even);
            _context.SaveChanges();
        }

        public void Delete(Event even)
        {
            _context.Events.Remove(even);
            _context.SaveChanges();
        }

        public void Update(Event even)
        {
            var EventForUpdate = _context.Events.FirstOrDefault(x => x.Id == even.Id);

            EventForUpdate.Date = even.Date;
            EventForUpdate.Description = even.Description;
            EventForUpdate.ImgUrl = even.ImgUrl;
            EventForUpdate.Location = even.Location;
            EventForUpdate.Name = even.Name;
            EventForUpdate.OrganizedBy = even.OrganizedBy;

            _context.Events.Update(EventForUpdate);
            _context.SaveChanges();
        }

        public List<Event> GetAll()
        {
            var events = _context.Events.ToList();
            return events;
        }

        public Event GetById(int id)
        {
            var even = _context.Events.FirstOrDefault(x => x.Id == id);
            return even;
        }

        public List<Event> GetByName(string name)
        {
            var events = _context.Events.Where(x => x.Name.Contains(name)).ToList();
            return events;
        }
    }
}
