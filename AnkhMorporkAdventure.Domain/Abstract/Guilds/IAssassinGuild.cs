using AnkhMorporkAdventure.Domain.Models;

namespace AnkhMorporkAdventure.Domain.Abstract.Guilds
{
    public interface IAssassinGuild
    {
        Assassin GetAssassin(decimal reward);
    }
}
