using Microsoft.EntityFrameworkCore;
using OverwatchApi.Models;
using OverwatchApi.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _user;

        public UserRepository(DataContext context)
        {
            _context = context;
            _user = _context.User;
        }

        public void Add(User user)
        {
            _user.Add(user);
        }

        public User GetBy(string username)
        {
            return _user.FirstOrDefault(t => t.Username == username);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
