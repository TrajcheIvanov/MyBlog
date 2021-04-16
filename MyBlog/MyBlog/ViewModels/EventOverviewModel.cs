

using System.Collections.Generic;

namespace MyBlog.ViewModels
{
    public class EventOverviewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string ImgUrl { get; set; }

        public string EventType { get; set; }

        public List<EventLikeModel> EventLikes { get; set; }

        
    }
}
