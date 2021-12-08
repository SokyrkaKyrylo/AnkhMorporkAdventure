using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Models;
using OOPCourse.Domain.Abstract;
using System.Collections.Generic;

namespace OOPCourse.Domain.Concrete
{
    public class AssassinsRepo : IAssassinsRepo
    {
        private ApplicationContext _context;

        public AssassinsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Assassin> Assassins => _context.Assassins;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
