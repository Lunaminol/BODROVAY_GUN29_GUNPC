namespace CasinoGame
{
    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number, int min, int max)
        : base($"Некорректное число {number}. Выберите число между {min} и {max}.")
        {
        }
    }
}
