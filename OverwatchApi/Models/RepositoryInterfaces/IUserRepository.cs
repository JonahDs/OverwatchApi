using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models.RepositoryInterfaces
{
    public interface IUserRepository
    {
        User GetBy(string user);
        void Add(User username);
        void SaveChanges();
    }
}
