using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class EventMoreInfoDataModel
    {
        public EventMoreInfoModel EventMoreInfo { get; set; }

        public EventSidebarDataModel SidebarData { get; set; } = new EventSidebarDataModel();
    }
}
