using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class EventLike
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
