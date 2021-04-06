using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult InternalError()
        {
            return View();
        }

        public IActionResult ErrorNotFound()
        {
            return View();
        }

        public IActionResult ActionNonSuccessful(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
