using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class EventLikeController : Controller
    {
        private IEventsLikeService _eventsLikeService;
        public EventLikeController(IEventsLikeService eventsLikeService)
        {
            _eventsLikeService = eventsLikeService;
        }

        public IActionResult Add(int eventId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _eventsLikeService.Add(eventId, userId);

            return RedirectToAction("Overview", "Events");
        }

        public IActionResult Remove(int eventId)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _eventsLikeService.Remove(eventId, userId);

            return RedirectToAction("Overview", "Events");
        }
    }
}
