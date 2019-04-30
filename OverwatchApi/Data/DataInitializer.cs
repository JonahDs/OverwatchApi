using Microsoft.AspNetCore.Identity;
using OverwatchApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data
{
    public class DataInitializer
    {
        private readonly DataContext _dbContext;
        private readonly UserManager<IdentityUser> _usermanger;
        public DataInitializer(DataContext dbContext, UserManager<IdentityUser> usermanager)
        {
            _dbContext = dbContext;
            _usermanger = usermanager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database at context
                User generic = new User { Email = "test@hotmail.com", Firstname = "firstname", Lastname = "lastname" };
                await CreateUser(generic.Email, "password");
                _dbContext.User.Add(generic);
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _usermanger.CreateAsync(user,password);
        }
    }
}
