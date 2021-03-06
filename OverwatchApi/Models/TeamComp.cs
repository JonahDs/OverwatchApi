﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models
{
    public class TeamComp
    {
        public int TeamCompId { get; set; }
        public int Rating { get; set; }
        public string TeamCompName { get; set; }
        public ICollection<HeroTeamComp> TeamCompHeroes { get; set; }

        public TeamComp()
        {
            this.TeamCompHeroes = new List<HeroTeamComp>();
        }

        public void AddHero(Hero hero)
        {
            HeroTeamComp htc = new HeroTeamComp(hero, this);
        }

    }
}
