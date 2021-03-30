using Microsoft.AspNetCore.Authorization;
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
    
    public class RegionsController : Controller
    {
        private IRegionsService _service { get; set; }

        public RegionsController(IRegionsService service)
        {
            _service = service;
        }

        public IActionResult Overview()
        {
            var regions = _service.GetAllRegions();
            return View(regions);
        }

        [HttpGet]
        [Authorize(Policy = "IsAdministrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "IsAdministrator")]
        public IActionResult Create(Region region)
        {
            if (ModelState.IsValid)
            {
                _service.CreateRegion(region);
                return RedirectToAction("Overview");
            }

            return View(region);
        }
    }
}
