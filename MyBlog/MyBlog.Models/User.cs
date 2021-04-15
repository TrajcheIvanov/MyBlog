using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime DateCreat { get; set; }

        public bool IsAdministrator { get; set; }

        public List<Comment> Comments { get; set; }

        public List<EventLike> EventLikes { get; set; }
    }
}
