using System;
using FinalTask;
using FinalTask.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 1. Создаём кость с диапазоном от 1 до 6
            Dice dice = new Dice(1, 6);

            // 2. Бросаем кость несколько раз
            Console.WriteLine("Броски кости:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Бросок {i + 1}: {dice.Number}");
            }

            // 3. Пробуем создать некорректную кость
            Console.WriteLine("\nПробуем создать кость с диапазоном 0–6:");
            Dice invalidDice = new Dice(0, 6); // должно вызвать исключение
        }
        catch (WrongDiceNumberException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}