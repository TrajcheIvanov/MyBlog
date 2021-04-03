using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class CommentCreateModel
    {
        public int EventId { get; set; }
        public string Comment { get; set; }
    }
}
