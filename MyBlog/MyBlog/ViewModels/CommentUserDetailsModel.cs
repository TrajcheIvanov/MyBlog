using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class CommentUserDetailsModel
    {
     
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public string EventName { get; set; } 
    }
}
