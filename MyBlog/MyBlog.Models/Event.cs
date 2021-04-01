
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Name")]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Location is mandatory")]
        public string Location { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string OrganizedBy { get; set; }
        [Required]
        public string ImgUrl {get;set;}

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
