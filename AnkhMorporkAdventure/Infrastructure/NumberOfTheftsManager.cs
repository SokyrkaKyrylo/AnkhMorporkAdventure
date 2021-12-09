namespace AnkhMorporkAdventure.Infrastructure
{
    public static class NumberOfTheftsManager
    {
        private static int _value = 1;

        public static int NumberOfThefts
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < 0)
                    return;
                _value = value;
            }
        }
    }
}