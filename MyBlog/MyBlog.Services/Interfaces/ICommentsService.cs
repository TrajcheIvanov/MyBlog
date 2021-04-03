using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int eventId, int userId);
    }
}
