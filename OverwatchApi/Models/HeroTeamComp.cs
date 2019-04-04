using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models
{
    public class HeroTeamComp
    {
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
        public int TeamCompId { get; set; }
        public TeamComp TeamComp { get; set; }
    }
}
