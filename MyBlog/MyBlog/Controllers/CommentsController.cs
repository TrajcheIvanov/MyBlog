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

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id, int eventId)
        {
            var response = _commentsService.Delete(id);

            try
            {
                if (response.IsSuccessful)
                {
                    return RedirectToAction("MoreInfo", "Events", new { SuccessMessage = "Comment deleted sucessfully" , id = eventId });
                }
                else
                {
                    return RedirectToAction("MoreInfo", "Events", new { ErrorMessage = response.Message , id = eventId });
                }
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorNotFound", "Info");
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult Update(int id, int eventId)
        {
            return RedirectToAction("MoreInfo", "Events", new { commentForUpdateId = id, id = eventId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(CommentUpdateModel commentUpdateModel)
        {
            var response = _commentsService.Update(commentUpdateModel.Id, commentUpdateModel.Comment);

            try
            {
                if (response.IsSuccessful)
                {
                    return RedirectToAction("MoreInfo", "Events", new { SuccessMessage = "Comment updated sucessfully", id = commentUpdateModel.EventId });
                }
                else
                {
                    return RedirectToAction("MoreInfo", "Events", new { ErrorMessage = response.Message, id = commentUpdateModel.EventId });
                }
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorNotFound", "Info");
            }


        }
    }
}
