using System;

namespace FinalTask.Exceptions
{     

public class WrongDiceNumberException : Exception
{
    public WrongDiceNumberException(int number, int max)
        : base($"Invalid dice number: {number}. Allowed range is 1 to {max}.")
    {
    }
}
}
