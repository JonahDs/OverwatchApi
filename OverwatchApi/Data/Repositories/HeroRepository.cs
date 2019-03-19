using Microsoft.EntityFrameworkCore;
using OverwatchApi.Models;
using OverwatchApi.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Hero> _heroes;

        public HeroRepository(DataContext dbContext)
        {
            _context = dbContext;
            _heroes = dbContext.Heroes;
        }
        public IEnumerable<Hero> GetAll()
        {
            return _heroes.Include(t => t.Abilities).ToList();
        }

        public Hero GetHeroBy(int id)
        {
            return _heroes.Include(t => t.Abilities).FirstOrDefault(t => t.Id == id);
        }
    }
}
