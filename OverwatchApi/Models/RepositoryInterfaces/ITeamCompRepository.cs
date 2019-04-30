using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models.RepositoryInterfaces
{
    interface ITeamCompRepository
    {
        IEnumerable<TeamComp> GetAll();
        IEnumerable<TeamComp> GetAllRatingDesc();
    }
}
