using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MyBlog.Repositories
{
    public class RegionsFileRepository : IRegionsRepository
    {

        const string Path = "Regions.txt";
        public RegionsFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Region>>(result);
            Regions = deserialzedList;

           
        }

        public List<Region> Regions { get; set; }

        public List<Region> GetAll()
        {
            return Regions;
        }

        public Region GetById(int id)
        {
            return Regions.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Region region)
        {
            region.Id = GenerateId();
            Regions.Add(region);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Regions.Any())
            {
                maxId = Regions.Max(x => x.Id);
            }

            return maxId + 1;
        }
        private void SaveChanges()
        {
            var serialzed = JsonConvert.SerializeObject(Regions);
            File.WriteAllText(Path, serialzed);
        }
    }
}
