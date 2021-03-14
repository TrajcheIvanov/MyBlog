using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MyBlog.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        const string Path = "Events.txt";

        public EventsRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Event>>(result);
            Events = deserialzedList;
        }

        public List<Event> Events { get; set; }

        public List<Event> GetAll()
        {
            return Events;
        }

        public Event GetById(int id)
        {
            return Events.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Event even)
        {
            even.Id = GenerateId();
            Events.Add(even);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Events.Any())
            {
                maxId = Events.Max(x => x.Id);
            }

            return maxId + 1;
        }
        private void SaveChanges()
        {
            var serialzed = JsonConvert.SerializeObject(Events);
            File.WriteAllText(Path, serialzed);
        }
    }
}
