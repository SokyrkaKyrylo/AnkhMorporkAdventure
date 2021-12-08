using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Models;
using OOPCourse.Domain.Abstract;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
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
