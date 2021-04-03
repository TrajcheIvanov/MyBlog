using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CommentCreateModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            _commentsService.Add(commentCreateModel.Comment, commentCreateModel.EventId, userId);

            return RedirectToAction("MoreInfo", "Events", new { id = commentCreateModel.EventId });
        }
    }
}
