using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class RegionsRepository : IRegionsRepository
    {
        private MyBlogDbContext _context { get; set; }

        public RegionsRepository(MyBlogDbContext context)
        {
            _context = context;
        }
        public void Add(Region region)
        {
            _context.Regions.Add(region);
            _context.SaveChanges();
        }

        public List<Region> GetAll()
        {
            var result = _context.Regions.ToList();
            return result;
        }

        public Region GetById(int id)
        {
            var result = _context.Regions.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
