﻿using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class RegionsRepository : BaseRepository<Region>, IRegionsRepository
    {

        public RegionsRepository(MyBlogDbContext context) : base(context)
        {
        }
        
    }
}
