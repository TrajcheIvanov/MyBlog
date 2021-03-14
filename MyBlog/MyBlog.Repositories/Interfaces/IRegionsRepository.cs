using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories.Interfaces
{
    public interface IRegionsRepository
    {
        List<Region> GetAll();


        Region GetById(int id);

        void Add(Region recipe);

    }
}