using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models
{
    public class HeroProperties
    {
        #region Properties
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int HealingPerSecond { get; set; }
        public int DamagePerSecond { get; set; }
        public int DifficultyRating { get; set; }
        #endregion

        public HeroProperties(int heroId)
        {
            HeroId = heroId;
        }


    }
}
