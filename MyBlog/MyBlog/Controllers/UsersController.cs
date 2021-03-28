using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Mappings;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
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
        public IActionResult Details(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var userId = User.FindFirst("Id").Value;

            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            
            return View(user.ToDetailsModel());
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update()
        {
            var userId = User.FindFirst("Id").Value;
            var user = _usersService.GetDetails(userId);

            if (user == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(user.ToUpdateModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(UserUpdateModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userModel = user.ToModel();
                    userModel.Id = int.Parse(User.FindFirst("Id").Value);
                    var response = _usersService.Update(userModel);

                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("Details", new { SuccessMessage = "User udpated sucessfully" });
                    }
                    else
                    {
                        return RedirectToAction("Details", new { ErrorMessage = response.Message });
                    }
                }
                catch (Exception)
                {

                    return RedirectToAction("ErrorNotFound", "Info");
                }

            }
            else
            {
                return View(user);
            }
        }
    }
}
