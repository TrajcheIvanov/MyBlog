using Microsoft.AspNetCore.Mvc;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class EventsController : Controller
    {
        private EventsService _service { get; set; }

        public EventsController()
        {
            _service = new EventsService();
        }
        public IActionResult Overview()
        {
            var events = _service.GetAllEvents();
            return View(events);
        }

        public IActionResult MoreInfo(int id)
        {
            var even = _service.GetEventById(id);

            return View(even);
        }
    }
}
