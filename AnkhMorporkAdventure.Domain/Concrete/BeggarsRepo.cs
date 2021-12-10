using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class BeggarsRepo : IBeggarsRepo
    {
        private ApplicationContext _context;

        public BeggarsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Beggar GetBeggar()
        {
            var rand = new System.Random();
            var beggars = _context.Beggars.ToList();
            int res = rand.Next(1, beggars.Count + 1);
            return beggars
                .FirstOrDefault(t => t.Id == res);
        }
    }
}
