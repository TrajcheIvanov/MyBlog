using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IRegionsService
    {
         List<Region> GetAllRegions();


         Region GetRegionById(int id);

        void CreateRegion(Region region);


    }
}
