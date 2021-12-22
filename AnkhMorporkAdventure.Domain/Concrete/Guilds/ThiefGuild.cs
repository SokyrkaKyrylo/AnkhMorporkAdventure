using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkAdventure.Domain.Concrete.Guilds
{
    public class ThiefGuild : IThiefGuild
    {
        private readonly IEnumerable<Thief> _thieves;

        public ThiefGuild(IEnumerable<Thief> npcs)
        {
            _thieves = npcs;
        }

        public Thief GetThief()
        {
            var rand = new System.Random();
            var thieves = _thieves.ToList();
            int res = rand.Next(1, thieves.Count + 1);
            return thieves
                .FirstOrDefault(t => t.Id == res);
        }
    }
}
