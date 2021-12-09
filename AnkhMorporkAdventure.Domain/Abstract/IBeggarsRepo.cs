using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Abstract
{
    public interface IBeggarsRepo
    {
        IEnumerable<Beggar> Beggars { get; }
    }
}
