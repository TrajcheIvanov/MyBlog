using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Common.Exceptions;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Linq;

namespace MyBlog.Controllers
{   
    [Authorize(Policy = "IsAdministrator")]
    public class EventsController : Controller
    {
        private IEventsService _service { get; set; }

        public EventsController(IEventsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Overview(string name)
        {
            var events = _service.GetEventByName(name);

            var eventOverviewModels = events.Select(x => x.ToOverviewModel()).ToList();

            return View(eventOverviewModels);
        }

        public IActionResult ManageEvents(string errorMessage, string successMessage, string updateMessage)
        {
            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.UpdateMessage = updateMessage;
            var events = _service.GetAllEvents();

            var viewModels = events.Select(x => x.ToManageEventsModel()).ToList();
            return View(viewModels);
        }

        [AllowAnonymous]
        public IActionResult MoreInfo(int id)
        {
            try
            {
                var even = _service.GetEventById(id);
                if (even == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                return View(even.ToMoreInfoModel());
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
        public IActionResult Create(EventCreateModel even)
        {
            if(ModelState.IsValid)
            {
                _service.CreateEvent(even.ToModel());
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

        [HttpGet]
        public IActionResult Update(int Id)
        {
            try
            {
                var even = _service.GetEventById(Id);

                if (even != null)
                {
                    return View(even);
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

      

        [HttpPost]
        public IActionResult Update(EventUpdateModel even)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(even.ToModel());
                    return RedirectToAction("ManageEvents", new { UpdateMEssage = "Event updated sucessfully" });
                }
                catch (NotFoundException ex)
                {

                    return RedirectToAction("ManageEvents", new { ErrorMessage = ex.Message });
                }
                catch (Exception)
                {

                    return RedirectToAction("InternalError", "Info");
                }

            }
            else
            {
                return RedirectToAction("InternalError", "Info");
            }
        }
    }
}
