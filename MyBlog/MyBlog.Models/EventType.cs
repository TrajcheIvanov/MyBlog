﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
