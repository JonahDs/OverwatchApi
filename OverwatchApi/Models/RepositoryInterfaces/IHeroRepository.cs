using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models.RepositoryInterfaces
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetAll();
        Hero GetHeroBy(int id);
    }
}
