using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels
{
    public class EventCreateModel
    {
        [Required(ErrorMessage = "Please enter Name")]
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
        public string ImgUrl { get; set; }

        public int EventTypeId { get; set; }

        public List<EventTypeModel> EventTypes { get; set; }

    }
}
