using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        
        public UsersRepository(MyBlogDbContext context) : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

      
        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public override User GetById(int entityId)
        {
            var user = _context.Users
                .Include(x => x.Comments)
                .ThenInclude(x => x.Event).ToList()
                //    .ThenInclude(x => x.Name)
                .FirstOrDefault(x => x.Id == entityId);

            return user;
        }

    }
}
