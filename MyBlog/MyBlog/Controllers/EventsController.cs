using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Common.Exceptions;
using MyBlog.Common.Models;
using MyBlog.Common.Services;
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

        private ISidebarService _sidebarService { get; set; }

        private ILogService _logService;

        private IEventsTypeService _eventsTypeService;

        public EventsController(
            IEventsService service, 
            ISidebarService sidebarService, 
            ILogService logService,
            IEventsTypeService eventsTypeService
            )
        {
            _service = service;
            _sidebarService = sidebarService;
            _logService = logService;
            _eventsTypeService = eventsTypeService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string name)
        {

            var events = _service.GetEventsWithFilters(name);
            var overviewDataModel = new EventOverviewDataModel();

            var eventOverviewModels = events.Select(x => x.ToOverviewModel()).ToList();
            overviewDataModel.OverviewEvents = eventOverviewModels;
            overviewDataModel.SidebarData = _sidebarService.GetSideBarData();


            return View(overviewDataModel);
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
        public IActionResult MoreInfo(int id , string errorMessage, string successMessage, int commentForUpdateId)
        {

            ViewBag.SuccessMessage = successMessage;
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.CommentForUpdateId = commentForUpdateId;

            try
            {
                var even = _service.GetEventDetails(id);
                if (even == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var eventMoreInfoDataModel = new EventMoreInfoDataModel();
                eventMoreInfoDataModel.EventMoreInfo = even.ToMoreInfoModel();
                eventMoreInfoDataModel.SidebarData = _sidebarService.GetSideBarData();


                return View(eventMoreInfoDataModel);
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorNotFound", "Info");
            }
            

            
        }

        [HttpGet]
        public IActionResult Create()
        {
            var eventTypes = _eventsTypeService.GetAll();
            var viewModels = eventTypes.Select(x => x.ToEventTypeModel()).ToList();

            var viewModel = new EventCreateModel();
            viewModel.EventTypes = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(EventCreateModel even)
        {
            if(ModelState.IsValid)
            {
                _service.CreateEvent(even.ToModel());
                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with id {userId} created recipe {even.Name}" };
                _logService.Log(logData);
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
                    var viewModel = even.ToUpdateModel();

                    var eventTypes = _eventsTypeService.GetAll();
                    var viewModels = eventTypes.Select(x => x.ToEventTypeModel()).ToList();

                    viewModel.EventTypes = viewModels;
                    return View(viewModel);
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
