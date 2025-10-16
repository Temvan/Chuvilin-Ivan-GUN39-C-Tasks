using System;
using System.Text;

namespace Strings
{
    internal class StrokesAndSymbols

    {
        // Метод для для конкатенации двух строк
        static void ConcatenateStrings(string str1, string str2)
        {
            string string1 = str1;
            string string2 = str2;
            string string3 = " ";
            string result = string1 + string3 + string2;
            Console.WriteLine(result);
        }

        // Метод встречи пользователя

        static void GreetUser(string name, int age)
        {
            Console.WriteLine($"Hello, {name}! \nYou are {age} years old.");
        }

        // Метод возврата длины строки и строку в верхнем и нижнем регистре 

        static void StringInfo(string input)
        {
            string str = input;
            int length = str.Length;
            string upperStr = str.ToUpper();
            string lowerStr = str.ToLower();

            Console.WriteLine($"Length: {length}");
            Console.WriteLine($"Uppercase: {upperStr}");
            Console.WriteLine($"Lowercase: {lowerStr}");
        }


        // Возврат 5 символов из строки
        static string GetFirstFiveChars(string input)
        {
            return input.Substring(0, 5);
        }

        // Метод принимающий на вход массив из строк и возвращающий экземпляр StringBuilder
        static StringBuilder BuildStringFromArray(string[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in arr)
            {
                sb.Append(str);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
            return sb;
        }

        // метод принятия строки, одно слово для поиска и одно слово для замены
        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {
            return inputString.Replace(wordToReplace, replacementWord);
        }

        static void Main(string[] args)
        {
            // Запрос ввода двух строк у пользователя
            Console.WriteLine("Enter first text:");
            string text1 = Console.ReadLine();
            Console.WriteLine("Enter second text:");
            string text2 = Console.ReadLine();

            ConcatenateStrings(text1, text2);

            // Запрос ввода имени и возраста пользователя
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            GreetUser(name, age);

            // Запрос ввода строки для информации о ней
            Console.WriteLine("Enter a text:");
            string text = Console.ReadLine();
            StringInfo(text);

            // Запрос ввода строки для получения первых 5 символов
            Console.WriteLine("Enter a text for return 5 symbols:");
            string input = Console.ReadLine();
            string firstFiveChars = GetFirstFiveChars(input);
            Console.WriteLine($"First 5 characters: {firstFiveChars}");

            // Запрос ввода количества строк для массива
            Console.WriteLine("Enter number of strings in array:");
            int n = int.Parse(Console.ReadLine());
            string[] stringArray = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter string {i + 1}:");
                stringArray[i] = Console.ReadLine();
            }
            BuildStringFromArray(stringArray);

            // Запрос ввода строки, слова для поиска и для замены
            string result = ReplaceWords("Hello world", "world", "universe");
            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
} 