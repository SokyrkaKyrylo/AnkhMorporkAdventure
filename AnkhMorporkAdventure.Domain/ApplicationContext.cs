using AnkhMorporkAdventure.Domain.Models;
using System.Data.Entity;

namespace AnkhMorporkAdventure.Domain
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Thief> Thieves { get; set; }
        public DbSet<Beggar> Beggars { get; set; }
        public DbSet<Fool> Fools { get; set; }        
        public DbSet<Item> Products { get; set; }

        private static ApplicationContext _context;

        private ApplicationContext()
        {
        }

        public static ApplicationContext GetInstance()
        {
            if (_context == null)
                _context = new ApplicationContext();
            return _context;
        }
    }
}
