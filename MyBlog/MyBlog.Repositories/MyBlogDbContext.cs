using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repositories
{
    public class MyBlogDbContext : DbContext
    {

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext>options): base (options)
        {}

        public DbSet<Event> Events { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
