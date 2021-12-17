namespace AnkhMorporkAdventure.Infrastructure
{
    public class MoneyConvertor
    {
        public static string Convert(decimal reward)
        {
            if (reward < 1)
                return $"{reward * 100} pennies";
            return $"{reward} dollars";
        }
    }
}