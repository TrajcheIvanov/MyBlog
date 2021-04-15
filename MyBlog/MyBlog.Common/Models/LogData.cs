using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common.Models
{
    public class LogData
    {
        public LogType Type { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
