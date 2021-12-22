using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkAdventure.Domain.Concrete.Guilds
{
    public class FoolGuild : IFoolGuild
    {
        private readonly IEnumerable<Fool> _fools;

        public FoolGuild(IEnumerable<Fool> fools)
        {
            _fools = fools;
        }

        public Fool GetFool()
        {
            var rand = new System.Random();
            var fools = _fools.ToList();
            int res = rand.Next(1, fools.Count + 1);
            return fools
                .FirstOrDefault(t => t.Id == res);
        }
    }
}
