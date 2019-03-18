using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models
{
    public class Hero
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int Dps { get; set; }
        public int HealingAmount { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }
        public int Shield { get; set; }
        public IEnumerable<HeroAbilitie> Abilities { get; set; }
        #endregion

        #region Constructor
        public Hero()
        {
            Abilities = new List<HeroAbilitie>();
        }
        #endregion
    }
}
