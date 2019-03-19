using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverwatchApi.Models
{
    public class HeroAbilitie
    {
        #region Properties
        public int Id { get; set; }
        public string LeftClick { get; set; }
        public string RightClick { get; set; }
        public string MainAbilityOne { get; set; }
        public string MainAbilityTwo { get; set; }
        public string Ultimate { get; set; }
        #endregion

        #region Constructor
        public HeroAbilitie(string leftclick, string rightclick, string abOne, string abTwo, string ult)
        {
            LeftClick = leftclick;
            RightClick = rightclick;
            MainAbilityOne = abOne;
            MainAbilityTwo = abTwo;
            Ultimate = ult;
        }
        public HeroAbilitie()
        {

        }
        #endregion
    }
}
