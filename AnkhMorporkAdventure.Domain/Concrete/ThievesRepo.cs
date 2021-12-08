using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Models;
using OOPCourse.Domain.Abstract;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
{
    public class ThievesRepo : IThievesRepo
    {
        private ApplicationContext _context;

        public ThievesRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Thief> Thieves => _context.Thieves;
    }
}
