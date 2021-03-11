using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string PointsOfInterest { get; set; }

        public string ExternalLink { get; set; }
    }
}
