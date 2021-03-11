using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string OrganizedBy { get; set; }
        public string ImgUrl {get;set;}
    }
}
