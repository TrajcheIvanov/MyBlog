using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class EventsController : Controller
    {
        private IEventsService _service { get; set; }

        public EventsController(IEventsService service)
        {
            _service = service;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event even)
        {
            if(ModelState.IsValid)
            {
                _service.CreateEvent(even);
                return RedirectToAction("Overview");
            }

            return View(even);
        }
    }
}
