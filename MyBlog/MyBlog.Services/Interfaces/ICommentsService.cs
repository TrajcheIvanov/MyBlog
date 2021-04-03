using MyBlog.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int eventId, int userId);
        StatusModel Delete(int id);
        StatusModel Update(int id, string comment);
    }
}
