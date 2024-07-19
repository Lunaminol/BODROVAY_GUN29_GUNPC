using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public class DiceGame : CasinoGameBase   
    {
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly List<Dice> _dices;

        public DiceGame(int numberOfDice, int min, int max)
        {
            _diceCount = numberOfDice;
            _minValue = min;
            _maxValue = max;
            _dices = new List<Dice>();
            FactoryMethod();
        }

        public override void PlayGame()
        {
            Console.WriteLine("Starting a game of Dice...");

            int playerScore = RollDice();
            int computerScore = RollDice();

            Console.WriteLine($"Player's score: {playerScore}");
            Console.WriteLine($"Computer's score: {computerScore}");

            if (playerScore > computerScore)
            {
                Console.WriteLine("Player wins!");
                OnWinInvoke();
            }
            else if (playerScore < computerScore)
            {
                Console.WriteLine("Computer wins!");
                OnLooseInvoke();
            }
            else
            {
                Console.WriteLine("It's a draw!");
                OnDrawInvoke();
            }
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_minValue, _maxValue));
            }
        }

        private int RollDice()
        {
            int totalScore = 0;
            foreach (var dice in _dices)
            {
                totalScore += dice.Number;
            }
            return totalScore;
        }
    }
}
