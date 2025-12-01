using System;
using FinalTask.Exceptions;

namespace FinalTask
{
    public struct Dice
    {
        private readonly int _min;
        private readonly int _max;
        private static readonly Random _random = new Random();

        public int Number => _random.Next(_min, _max + 1);

        public Dice(int min, int max)
        {
            if (min <= 0 || max <= 0 || min >= max)
            {
                throw new WrongDiceNumberException(min, max);
            }

            _min = min;
            _max = max;
        }
    }
}