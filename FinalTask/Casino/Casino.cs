using System;
using System.Collections.Generic;
using System.Runtime;
using FinalTask;
using FinalTask.Casino.CasinoGames;
using FinalTask.SaveLoad;
using FinalTask.SaveLoad.Data;

namespace FinalTask.Casino
{
    public class Casino : IGame
    {
        private readonly ISaveLoadService<PlayerData> _saveLoadService;
        private PlayerData _playerData;

        private readonly CasinoGameBase _blackjackGame;
        private readonly CasinoGameBase _diceGame;

        private const int MaxBank = 1000000;

        public Casino(ISaveLoadService<PlayerData> saveLoadService, CasinoGameBase blackjack, CasinoGameBase dice)
        {
            _saveLoadService = saveLoadService ?? throw new ArgumentNullException(nameof(saveLoadService));
            _blackjackGame = blackjack;
            _diceGame = dice;

            SubscribeToEvents(_blackjackGame);
            SubscribeToEvents(_diceGame);          
        }

        private void SubscribeToEvents(CasinoGameBase game)
        {
            game.OnWin += () => Console.WriteLine("You win!");
            game.OnLose += () => Console.WriteLine("You lose!");
            game.OnDraw += () => Console.WriteLine("Draw!");
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the Casino!");
            LoadOrCreateProfile();

            if (_playerData.Bank > MaxBank)
            {
                _playerData.Bank /= 2;
                Console.WriteLine("You wasted half of your bank money in casino’s bar.");
            }

            if (_playerData.Bank <= 0)
            {
                Console.WriteLine("No money? Kicked!");
                return;
            }

            CasinoGameBase selectedGame = ChooseGame();

            Console.WriteLine("Starting game...");
            Console.WriteLine($"Current bank: {_playerData.Bank}");

            int bet = GetBet();

            bool? result = null;
            void OnWinHandler() => result = true;
            void OnLoseHandler() => result = false;
            void OnDrawHandler() => result = null;

            selectedGame.OnWin += OnWinHandler;
            selectedGame.OnLose += OnLoseHandler;
            selectedGame.OnDraw += OnDrawHandler;

            selectedGame.StartGame();

            selectedGame.OnWin -= OnWinHandler;
            selectedGame.OnLose -= OnLoseHandler;
            selectedGame.OnDraw -= OnDrawHandler;

            ApplyBetResult(result, bet);



            SaveData();

            Console.WriteLine($"Thanks for playing! Your current bank: {_playerData.Bank}");
        }
      
        private void LoadOrCreateProfile()
        {
            try
            {
                _playerData = _saveLoadService.LoadData("PlayerProfile");
                Console.WriteLine($"Profile loaded. Welcome back, {_playerData.Name}!");
            }
            catch (Exception ex)
            {
                Console.Write("Enter your name:");
                string name = Console.ReadLine() ?? "Player";
                Console.WriteLine("");
                Console.Write("Enter your age:");
                int age = int.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine("");
                _playerData = new PlayerData(name, age, 1000);

                Console.WriteLine($"New profile is created. Welcome {_playerData.Name}!");
                Console.WriteLine($"Starting bank: {_playerData.Bank}");

            }
        }

        private CasinoGameBase ChooseGame()
        {
            Console.WriteLine("Choose a game:");
            Console.WriteLine("1. Blackjack");
            Console.WriteLine("2. Dice");

            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        return _blackjackGame;
                    case "2":
                        return _diceGame;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                    break;
                }
            }
        }
        private int GetBet()
        {
            Console.WriteLine("Enter your bet:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int bet) && bet > 0 && bet <= _playerData.Bank)
                {
                    return bet;
                }
                else
                {
                    Console.WriteLine($"Invalid bet. Please try again!");
                }
                
            }
        }
        private void ApplyBetResult(bool? result, int bet)
        {
            if (result == true)
            {
                long newBank = (int)_playerData.Bank + bet;
                if (newBank > int.MaxValue)
                {
                    _playerData.UpdateBank(_playerData.Bank / 2);
                    Console.WriteLine("You wasted half of your bank money in casino's bar");
                }
                else
                {
                    _playerData.IncreaseBank(bet);

                    if (_playerData.Bank > MaxBank)
                    {
                        _playerData.UpdateBank(MaxBank);
                        Console.WriteLine($"Congratulations! Your bank exceeded the maximum limit. It has been set to {MaxBank}.");
                        Console.WriteLine("You bankrupt the casino. They will build a new one in your place.");

                    }
                    else
                    {
                        Console.WriteLine($"You won {bet}.");
                    }
                }
            }
            else if (result == false)
            {
                _playerData.DecreaseBank(bet);
                if (_playerData.Bank < 0)
                {
                    _playerData.UpdateBank(0);
                }

                Console.WriteLine($"You lost {bet}.");
            }
            else
            {
                Console.WriteLine("Draw! Casino returned your bet.");
            }

            Console.WriteLine($"Current bank: {_playerData.Bank}");
        }


        private void SaveData()
        {
            try 
            {
                _saveLoadService.SaveData(_playerData, "PlayerProfile");
                Console.WriteLine("Profile saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving profile: {ex.Message}");
            }
        }
    }   
}