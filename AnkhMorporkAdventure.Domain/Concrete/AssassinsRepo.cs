using AnkhMorporkAdventure.Domain;
using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Linq;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class AssassinsRepo : IAssassinsRepo
    {
        private ApplicationContext _context;

        public AssassinsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public Assassin GetAssassin(decimal reward)
        {
            var assassin = _context.Assassins
                .AsEnumerable()
                .FirstOrDefault(a => a.HighRewardBound >= reward && a.LowRewardBound <= reward);
            if (assassin != null)
            {
                assassin.Status = false;
                _context.SaveChanges();
            }
            return assassin;
        }      
    }
}
