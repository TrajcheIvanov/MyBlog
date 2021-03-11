using Microsoft.AspNetCore.Mvc;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class RegionsController : Controller
    {
        private RegionsService _service { get; set; }

        public RegionsController()
        {
            _service = new RegionsService();
        }

        public IActionResult Overview()
        {
            var regions = _service.GetAllRegions();
            return View(regions);
        }
    }
}
