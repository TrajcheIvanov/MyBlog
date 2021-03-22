using Microsoft.AspNetCore.Mvc;
using MyBlog.Common.Exceptions;
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
        public IActionResult Overview(string name)
        {
            var events = _service.GetEventByName(name);
            return View(events);
        }

        public IActionResult ManageEvents(string errorMessage, string successMessage, string updateMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.UpdateMessage = updateMessage;
            var events = _service.GetAllEvents();
            return View(events);
        }

        public IActionResult MoreInfo(int id)
        {
            try
            {
                var even = _service.GetEventById(id);
                if (even == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(even);
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorNotFound", "Info");
            }
            

            
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
                return RedirectToAction("ManageEvents", new { SuccessMessage = "Event created sucessfully" });
            }

            return View(even);
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                _service.Delete(Id);
                return RedirectToAction("ManageEvents", new { SuccessMessage = "Event deleted sucessfully" });
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ManageEvents", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {

                return RedirectToAction("InternalError","Info");
            }
        }

        public IActionResult Edit(int Id)
        {
            try
            {
                var even = _service.GetEventById(Id);

                if (even != null)
                {
                    return RedirectToAction("EditEvent", "Events", even);
                }
                else
                {
                    throw new NotFoundException($"The Event with Id {Id} was not found");
                }

            }
            catch (NotFoundException ex)
            {

                return RedirectToAction("ManageEvents", new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        public IActionResult EditEvent(Event even)
        {
            return View(even);
        }

        [HttpPost]
        public IActionResult Update(Event even)
        {
            if (ModelState.IsValid)
            {
                _service.Update(even);
                return RedirectToAction("ManageEvents", new { UpdateMEssage = "Event updated sucessfully" });
            }
            else
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
    }
}
