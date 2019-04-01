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
        public bool CanHeal { get; set; }
        public int Health { get; set; }
        public int Armour { get; set; }
        public int Shield { get; set; }
        public ICollection<HeroProperties> Properties { get; set; }
        public ICollection<TeamComp> TeamComps { get; set; }
        #endregion

        #region Constructor
        public Hero()
        {
            this.Properties = new List<HeroProperties>();
            this.TeamComps = new List<TeamComp>();
        }
        #endregion

        #region Methodes
        public HeroProperties GetHeroProperty(int id) => Properties.SingleOrDefault(t => t.HeroId == id);
        #endregion
    }
}
