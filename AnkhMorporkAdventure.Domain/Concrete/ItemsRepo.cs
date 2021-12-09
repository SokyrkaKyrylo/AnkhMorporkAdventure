using AnkhMorporkAdventure.Domain.Abstract;
using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class ItemsRepo : IItemsRepo
    {
        private ApplicationContext _context;

        public ItemsRepo(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> Items => _context.Products;
    }
}
