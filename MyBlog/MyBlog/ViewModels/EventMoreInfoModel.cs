
using System;
using System.Collections.Generic;

namespace MyBlog.ViewModels
{
    public class EventMoreInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Location { get; set; }
     
        public string Date { get; set; }
        
        public string Description { get; set; }
        
        public string OrganizedBy { get; set; }
        
        public string ImgUrl { get; set; }

        public DateTime DateCreated { get; set; }

        public List<EventCommentModel> Comments { get; set; }

        
    }
}
