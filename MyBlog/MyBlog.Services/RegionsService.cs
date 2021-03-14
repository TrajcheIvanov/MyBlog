using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public class RegionsService : IRegionsService
    {
        private IRegionsRepository _regionRepository { get; set; }

        public RegionsService(IRegionsRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public List<Region> GetAllRegions()
        {
            return _regionRepository.GetAll();
        }

        public Region GetRegionById(int id)
        {
            return _regionRepository.GetById(id);
        }

        public void CreateRegion(Region region)
        {
            _regionRepository.Add(region);
        }
    }
}
