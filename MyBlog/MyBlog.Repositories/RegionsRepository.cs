using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class RegionsRepository
    {
        public List<Region> Regions { get; set; }

        public RegionsRepository()
        {
            var region1 = new Region()
            {
                Id = 1,
                Name = "Vodno",
                Location = "Skopje",
                PointsOfInterest = "Cableway, Lots Of Trails, Bars",
                ExternalLink = "https://en.wikipedia.org/wiki/Vodno"
            };

            var region2 = new Region()
            {
                Id = 2,
                Name = "Mavrovo",
                Location = "Mavrovo",
                PointsOfInterest = "Cableway, Lots Of Trails, Lake",
                ExternalLink= "https://en.wikipedia.org/wiki/Mavrovo_(region)"
            };

            var region3 = new Region()
            {
                Id = 3,
                Name = "Popova Shapka",
                Location = "Tetovo",
                PointsOfInterest = "Cableway, Lots Of Trails, Water by the way",
                ExternalLink= "https://en.wikipedia.org/wiki/%C5%A0ar_Mountains"
            };


            Regions = new List<Region> { region1, region2, region3 };
        }

        public List<Region> GetAll()
        {
            return Regions;
        }

        public Region GetById(int id)
        {
            return Regions.FirstOrDefault(x => x.Id == id);
        }
    }
}
