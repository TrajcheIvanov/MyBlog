using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class EventsRepository
    {
        public List<Event> Events { get; set; }

        public EventsRepository()
        {
            var event1 = new Event()
            {
                Id = 1,
                Name = "Mariovo OFF Road Experiance",
                Location = "Mariovo",
                Date = "07-09 May",
                Description = "The whole event covers both days of the weekend. In Saturday we set up the camp where the bikers stay, have party and meet each other. This is a great opportunity to spend some more time on the open air.",
                OrganizedBy = "VELOEVROPA",
                ImgUrl = "https://i.ytimg.com/vi/quhg7ktOe34/hqdefault.jpg"
            };

            var event2 = new Event()
            {
                Id = 2,
                Name = "Galichicha Tour",
                Location = "Resen",
                Date = "17-20 June",
                Description = "Then we ride down the valley in the middle of Galicica mountain. Nice off road trail with red send makes you feel like you are on planet Mars",
                OrganizedBy = "Prespa Bajk",
                ImgUrl = "https://s3-us-west-1.amazonaws.com/peakery-media/images/items/main/cache/magaro-1.jpg.480x360_q95.jpg"
            };

            var event3 = new Event()
            {
                Id = 3,
                Name = "Krushevo niz Korija",
                Location = "Mechkin kamen - Krushevo",
                Date = "14-15 August",
                Description = "camping on the historical site Meckin Kamen with organized party with DJs and bands, mountain biking, hiking tour in Krusevo, paraglide tandem flights and night race through the streets of the town. ",
                OrganizedBy = "Prilep Bike",
                ImgUrl = "https://i.pinimg.com/564x/60/92/49/609249b14325ab94e1fb5e4179e0784c.jpg"
            };
            Events = new List<Event> { event1, event2, event3 };
        }

        public List<Event> GetAll()
        {
            return Events;
        }

        public Event GetById(int id)
        {
            return Events.FirstOrDefault(x => x.Id == id);
        }
    }
}
