using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System;
using System.Linq;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class ThievesRepo : IThievesRepo
    {
        private ApplicationContext _context;

        public ThievesRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Thief GetThief()
        {
            var rand = new Random();
            var thieves = _context.Thieves.ToList();
            return thieves
                .FirstOrDefault(t => t.Id == rand.Next(1, thieves.Count));
        }
    }
}
