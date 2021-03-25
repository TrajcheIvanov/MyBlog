using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {

                var response = _authService.SignIn(signInModel.Username, signInModel.Password, HttpContext);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("Overview", "Events");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(signInModel);
                }

            }
            else
            {
                return View(signInModel);
            }
        }
    }
}
