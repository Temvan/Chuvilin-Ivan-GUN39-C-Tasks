using System.Reflection.Metadata;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Здесь массивы заданий 1-4
            // Задание 1. Массив Фибоначчи
            int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13 };
            foreach (var item in fibonacci)
            {
                Console.WriteLine(item);
            }
Console.WriteLine("-------------------");

            // Задание 2. Массив с месяцами

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
             foreach (var month in months)
            {
                Console.WriteLine(month);
            }
Console.WriteLine("-------------------");

            // Задание 3. Двумерный массив
            int[,] arraySecond = new int[3, 3]
             {
                { (int)Math.Pow(2, 1), (int)Math.Pow(3, 1), (int)Math.Pow(4, 1) },
                { (int)Math.Pow(2, 2), (int)Math.Pow(3, 2), (int)Math.Pow(4, 2) },
                { (int)Math.Pow(2, 3), (int)Math.Pow(3, 3), (int)Math.Pow(4, 3) },
            };
            for (int i = 0; i < arraySecond.GetLength(0); i++)
            {
                for (int j = 0; j < arraySecond.GetLength(1); j++)
                {
                    Console.WriteLine("" + i + "," + j + " = " + arraySecond[i, j]);
                }
            }
Console.WriteLine("-------------------");

            // Задание 4. Ломаный массив
            double[][] jaggedArray = new double[3][]
            {
                new double[] {1, 2, 3, 4 , 5},
                new double[] {(double)Math.E, (double)Math.PI},
                new double[] {(double)Math.Log10(1), (double)Math.Log10(10), (double)Math.Log10(100), (double)Math.Log10(1000)}
            };
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine("" + i + "," + j + " = " + jaggedArray[i][j]);
                }
            }

Console.WriteLine("-------------------");

            // массивы для заданий 5 и 6.
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            Array.Copy(array, 0, array2, 0, 3);
            var result = array2;
            // Выведите результат
            foreach (var item in result)
            {
                Console.WriteLine(item + " ");
            }

Console.WriteLine("-------------------");

                string[] sample = { "Apple", "Home" };
                Array.Resize(ref sample, 4);
                // Что же будет выведено?
                foreach (var item in sample)
                {
                    Console.WriteLine(item);
                }
        }
    }
}