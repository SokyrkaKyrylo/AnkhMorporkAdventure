using System;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class Player
    {
        public Player(decimal purse)
        {
            if (purse < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse = purse;
            Inventory = new Inventory();
        }

        public decimal Purse { get; private set; }

        public void AddMoney(decimal sum)
        {
            if (sum < 0)
                throw new ArgumentException("Money can not be less than zero");
            Purse += sum;
        }

        public bool GetMoney(decimal sum)
        {
            if (sum < 0)
                throw new ArgumentException("Money can not be less than zero");
            if (Purse < sum)
                return false;
            Purse -= sum;
            return true;
        }

        public Inventory Inventory { get; set; }
    }
}
