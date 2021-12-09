using AnkhMorporkAdventure.Domain.Models;

namespace AnkhMorporkAdventure.Domain.Abstract
{
    public interface IAssassinsRepo
    {
        Assassin GetAssassin(decimal reward);
    }
}
