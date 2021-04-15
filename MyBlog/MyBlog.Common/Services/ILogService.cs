using MyBlog.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Common.Services
{
    public interface ILogService
    {
        void Log(LogData logData);
    }
}
