namespace CasinoGame
{
    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;
        private readonly Random _random = new Random();
        public readonly int Number => _random.Next(_min, _max + 1);

        public Dice (int min, int max)
        {
            if (min < 1 || min > int.MaxValue)
            {
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            }

            if (max < 1 || max > int.MaxValue)
            {
                throw new WrongDiceNumberException(max, 1, int.MaxValue);
            }

            if (min > max)
            {
                throw new ArgumentException("Minimum value cannot be greater than maximum value.");
            }

            _min = min;
            _max = max;
        }

    }
}
