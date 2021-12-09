using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class BeggarsRepo : IBeggarsRepo
    {
        private ApplicationContext _context;

        public BeggarsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Beggar> Beggars => _context.Beggars;
    }
}
