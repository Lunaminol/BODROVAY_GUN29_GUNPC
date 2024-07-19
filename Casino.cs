using System.Reflection.Metadata;

namespace CasinoGame
{
    public class Casino : IGame, IBuilderSupporter
    {
        private ISaveLoadService<string> _saveLoadService;
        private CasinoGameBase _selectedGame;
        private string _playerName;
        private int _bank;
        private int _maxBank = 500;

        public void StartGame()
        {
            LoadPlayerProfile();

            while (_bank > 0)
            {
                ChooseGame();
                PlaceBets();
                _selectedGame.PlayGame();
                SavePlayerData();
            }
            ExitGame();
        }

        private void LoadPlayerProfile()
        {
            Console.WriteLine("Enter the player's name:");
            _playerName = Console.ReadLine();

            string data = _saveLoadService.LoadData(_playerName);

            if (data != null)
            {
                var parts = data.Split(',');
                _playerName = parts[0];
                _bank = int.Parse(parts[1]);
                if (_bank <= 0 )
                {
                    _bank = _maxBank;
                    Console.WriteLine($"Welcome back, {_playerName}! You have {_bank} to spend in our casino!");
                    SavePlayerData();
                }
                else 
                {
                    Console.WriteLine($"Welcome back {_playerName}! Your current bank is {_bank}.");
                }
            }
            
            else
            {
                _bank = _maxBank;
                Console.WriteLine($"Welcome, {_playerName}! You have {_bank} to spend in our casino!");
                SavePlayerData();
            } 
        }

        public void ChooseGame()
        {
            Console.WriteLine("To select a game, please write a number: 1 - Black Jack, 2 - Dice Game");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int gameChoice))
            {
                switch (gameChoice)
                {
                    case 1:
                        BuildCustom(new BlackJack(52));
                        Console.WriteLine("You selected Black Jack");
                        break;
                    case 2:
                        BuildCustom(new DiceGame(2, 1, 6));
                        Console.WriteLine("You selected Dice Game");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please select 1 - Black Jack, 2 - Dice Game");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select 1 - Black Jack, 2 - Dice Game");
            }
        }

        public void BuildService<T>(T service) where T : ISaveLoadService<string>
        {
            _saveLoadService = service;
        }

        private void PlaceBets()
        {
            Console.WriteLine($"Your current bank: {_bank}");

            bool validBet = false;
            while (!validBet)
            {
                Console.WriteLine("Place your bet:");
                if (int.TryParse(Console.ReadLine(), out int bet))
                {
                    if (bet > 0 && bet <= _bank)
                    {
                        _selectedGame.PlaceBet(bet); 
                        _selectedGame.ComputerPlaceBet(bet);
                        validBet = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid bet amount. Please place a bet between 1 and {_bank}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        public void BuildCustom<U>(U game) where U : CasinoGameBase
        {
            _selectedGame = game;

            _selectedGame.OnWin += HandleWin;
            _selectedGame.OnLoose += HandleLoose;
            _selectedGame.OnDraw += HandleDraw;
        }

        private void HandleWin(object sender, EventArgs e)
        {
            _bank += _selectedGame.PlayerBet * 2;
            Console.WriteLine($"Congratulations! You won {_selectedGame.PlayerBet * 2}! Now you have {_bank}!");
        }

        private void HandleLoose(object sender, EventArgs e)
        {
            _bank -= _selectedGame.PlayerBet; 
            Console.WriteLine($"You lost {_selectedGame.PlayerBet}. You have {_bank} left.");

            if (_bank == _maxBank/2)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
            }
            else if (_bank <= 0)
            {
                Console.WriteLine("No money ? Kicked!");
                ExitGame();
            }
        }

        private void HandleDraw(object sender, EventArgs e)
        {
            Console.WriteLine("It's a draw.");
        }

        private void SavePlayerData()
        {
            string data = $"{_playerName},{_bank}";
            _saveLoadService.SaveData(data, _playerName);
        }

        private void ExitGame()
        {
            Console.WriteLine("Thank you for playing! Goodbye.");
            SavePlayerData();
        }
    }
}
