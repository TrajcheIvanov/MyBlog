using MyBlog.Models;
using MyBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class RegionsService
    {
        private RegionsRepository _regionRepository { get; set; }

        public RegionsService()
        {
            _regionRepository = new RegionsRepository();
        }

        public List<Region> GetAllRegions()
        {
            return _regionRepository.GetAll();
        }

        public Region GetRegionById(int id)
        {
            return _regionRepository.GetById(id);
        }
    }
}
