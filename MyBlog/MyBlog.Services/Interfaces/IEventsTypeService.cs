using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IEventsTypeService
    {
        List<EventType> GetAll();
        bool CheckIfExists(int eventTypeId);
    }
}
