using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Data
{
    public class DataInitializer
    {
        private readonly DataContext _dbContext;
        public DataInitializer(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Console.WriteLine("create succesfull");
            }
        }
    }
}
