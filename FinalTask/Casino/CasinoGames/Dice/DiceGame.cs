using System;
using System.Collections.Generic;
using FinalTask.Casino.CasinoGames;

namespace FinalTask.Casino.CasinoGames.Dice
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _min;
        private readonly int _max;

        private readonly List<Dice> _playerDices = new();
        private readonly List<Dice> _dealerDices = new();

        public DiceGame(int diceCount, int min, int max)
        {
            if (diceCount < 1)
                throw new ArgumentOutOfRangeException(nameof(diceCount), "Dice must be >= 1");
            if (min < 1 || max < 1 || min > max)
                throw new ArgumentException("Something went wrong");

            _diceCount = diceCount;
            _min = min;
            _max = max;

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _playerDices.Clear();
            _dealerDices.Clear();

            for (int i = 0; i < _diceCount; i++)
            {
                _playerDices.Add(new Dice(_min, _max));
                _dealerDices.Add(new Dice(_min, _max));
            }
        }

        public override void StartGame()
        {
            int playerTotal = RollTotal(_playerDices);
            int dealerTotal = RollTotal(_dealerDices);

            Console.WriteLine($"Player rolled total: {playerTotal}");
            Console.WriteLine($"Dealer rolled total: {dealerTotal}");

            if (playerTotal > dealerTotal)
                {
                OnWinInvoke();
                }
            else if (playerTotal < dealerTotal)
                {
                OnLoseInvoke();
                }
            else
                {
                OnDrawInvoke();
                }
        }

        private static int RollTotal(IEnumerable<Dice> dices)
        {
            int total = 0;
            foreach (var dice in dices)
                total += dice.Number;
            return total;
        }
    }
}