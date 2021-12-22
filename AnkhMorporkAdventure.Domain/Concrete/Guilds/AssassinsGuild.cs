using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkAdventure.Domain.Concrete.Guilds
{
    public class AssassinsGuild : IAssassinGuild
    {
        private readonly IEnumerable<Assassin> _assassins;

        public AssassinsGuild(IEnumerable<Assassin> assassins)
        {
            _assassins = assassins;
        }

        public Assassin GetAssassin(decimal reward)
        {
            var assassin = _assassins
                .FirstOrDefault(a => a.HighRewardBound >= reward && a.LowRewardBound <= reward 
                && !a.Status);
            if (assassin != null)
            {
                assassin.Status = true;
            }
            return assassin;
        }
    }
}
