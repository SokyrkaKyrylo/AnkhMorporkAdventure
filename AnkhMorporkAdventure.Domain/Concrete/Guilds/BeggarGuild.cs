using AnkhMorporkAdventure.Domain.Abstract.Guilds;
using AnkhMorporkAdventure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkAdventure.Domain.Concrete.Guilds
{
    public class BeggarGuild : IBeggarGuild
    {
        private readonly IEnumerable<Beggar> _beggars;

        public BeggarGuild(IEnumerable<Beggar> beggars)
        {
            _beggars = beggars;
        }

        public Beggar GetBeggar()
        {
            var rand = new System.Random();
            var beggars = _beggars.ToList();
            int res = rand.Next(1, beggars.Count + 1);
            return beggars
                .FirstOrDefault(t => t.Id == res);
        }
    }
}
