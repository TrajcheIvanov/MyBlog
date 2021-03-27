using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class UsersController : Controller
    {
        private IUserServices _usersService;
        public UsersController(IUserServices usersService)
        {
            _usersService = usersService;
        }

        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirst("Id").Value;

            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            
            return View(user.ToDetailsModel());
        }
    }
}
