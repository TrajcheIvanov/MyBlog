using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Models
{
    public class Region
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PointsOfInterest { get; set; }
        [Required]
        public string ExternalLink { get; set; }
    }
}
