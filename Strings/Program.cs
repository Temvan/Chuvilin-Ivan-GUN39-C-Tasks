using System;
using System.Text;

namespace Strings
{
    internal class Program

    {
        static string[] _categories = { "Numbers", "Animals", };
        const string Value = "Const";
        
        static void Main(string[] args)
        {
            var categories = new Dictionary<int, string>()
            {
                { 1, _categories[0] },
                { 2, _categories[1] },
               
            };

            var categoryQuestions = new Dictionary<int, Dictionary<string, string>>();
            var questions = new Dictionary<string, string>()
            {
                {"PI", "3.14" },
                {"e", "2.71" },
                {"Lion", "King of the Jungle" },
                {"Elephant", "Largest land animal" },
            };

            categoryQuestions.Add(1, questions);
            categoryQuestions.Add(2, questions);

            Console.WriteLine("Select a category: 1 for Numbers, 2 for Animals");
            var selected = int.Parse(Console.ReadLine());
            Console.WriteLine("You selected: " + categories[selected]);
            var result = categoryQuestions[selected];
            foreach (var category in result)
            {
                Console.WriteLine("What is the value of: " + category.Key);
                int attempts = 0;
                while (true)
                {
                    var answer = Console.ReadLine();
                    attempts++;
                    if (attempts >= 3 || answer == category.Value)
                    {
                        Console.WriteLine("Too many attempts. The correct answer is: " + category.Value);
                        break;
                    }
                }
                if (attempts < 3)
                {
                Console.WriteLine("Correct!");
            
                }
                  break;
            }

          

        }
    }
}