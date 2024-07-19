using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    public class BlackJack : CasinoGameBase
    {
        private Queue<Card> _deck = new Queue<Card>();
        private List<Card> _cards = new List<Card>();
        private List<Card> _playerCards = new List<Card>();
        private List<Card> _computerCards = new List<Card>();
        private Random _random = new Random();

        public BlackJack(int numberOfCards) => FactoryMethod();

        public override void PlayGame()
        {
            DealCards(_playerCards, 2);
            DealCards(_computerCards, 2);

            Console.WriteLine($"Player's cards: {string.Join(", ", _playerCards)}");
            Console.WriteLine($"Computer's cards: {string.Join(", ", _computerCards)}"); ;

            DetermineWinner();
        }

        protected override void FactoryMethod()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Card card = new Card(suit, value);
                    _cards.Add(card);
                }
            }
            Shuffle();
        }

        private void Shuffle()
        {
            List<Card> shuffledCards = _cards.OrderBy(card => _random.Next()).ToList();
            _deck.Clear();
            foreach (var card in shuffledCards)
            {
                _deck.Enqueue(card);
            }
        }

        private void DealCards(List<Card> hand, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                if (_deck.Count > 0)
                {
                    hand.Add(_deck.Dequeue());
                }
                else
                {
                    Console.WriteLine("No cards left in the deck.");
                    Shuffle();
                }
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                switch (card.Value)
                {
                    case CardValue.Two:
                    case CardValue.Three:
                    case CardValue.Four:
                    case CardValue.Five:
                    case CardValue.Six:
                    case CardValue.Seven:
                    case CardValue.Eight:
                    case CardValue.Nine:
                    case CardValue.Ten:
                        score += (int)card.Value;
                        break;
                    case CardValue.Jack:
                    case CardValue.Queen:
                    case CardValue.King:
                        score += 10;
                        break;
                    case CardValue.Ace:
                        aceCount++;
                        break;
                }
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (score + 11 <= 21)
                {
                    score += 11;
                }
                else
                {
                    score += 1;
                }
            }

            return score;
        }
        private void DetermineWinner()
        {
            while (true)
            {
                int playerScore = CalculateScore(_playerCards);
                int computerScore = CalculateScore(_computerCards);

                if (playerScore > computerScore && playerScore <= 21)
                {
                    Console.WriteLine($"Player wins with {playerScore} points!");
                    OnWinInvoke();
                    break;
                }
                else if (computerScore > playerScore && computerScore <= 21)
                {
                    Console.WriteLine($"Computer wins with {computerScore} points!");
                    OnLooseInvoke();
                    break;
                }
                else if (playerScore == computerScore && playerScore < 21)
                {
                    Console.WriteLine("Draw, dealing one more card to each...");
                    DealCards(_playerCards, 1);
                    DealCards(_computerCards, 1);
                }
                else if (playerScore == computerScore && playerScore >= 21)
                {
                    Console.WriteLine("It's a draw with both scores being 21 or more!");
                    OnDrawInvoke();
                    break;
                }
                else if (playerScore <= 21 && computerScore > 21)
                {
                    Console.WriteLine($"Player wins with {playerScore} points! Computer busted with {computerScore} points.");
                    OnWinInvoke();
                    break;
                }
                else if (computerScore <= 21 && playerScore > 21)
                {
                    Console.WriteLine($"Computer wins with {computerScore} points! Player busted with {playerScore} points.");
                    OnLooseInvoke();
                    break;
                }
            }
        }
    }
}
