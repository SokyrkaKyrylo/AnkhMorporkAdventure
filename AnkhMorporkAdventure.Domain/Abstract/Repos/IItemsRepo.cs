using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Abstract
{
    public interface IItemsRepo
    {
        IEnumerable<Item> Items { get; }
    }
}
