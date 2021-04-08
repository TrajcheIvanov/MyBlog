using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class EventSidebarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
