using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class FoolsRepo : IFoolsRepo
    {
        private ApplicationContext _context;

        public FoolsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Fool GetFool()
        {
            var rand = new System.Random();
            var beggars = _context.Fools.ToList();
            int res = rand.Next(1, beggars.Count);
            return beggars
                .FirstOrDefault(t => t.Id == res);
        }
    }
}
