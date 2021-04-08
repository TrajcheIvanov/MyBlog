using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class EventSidebarDataModel
    {
        public List<EventSidebarModel> TopEvents { get; set; }

        public List<EventSidebarModel> MostRecentEvents { get; set; }
    }
}
