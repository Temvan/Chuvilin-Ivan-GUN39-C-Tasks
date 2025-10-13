using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace CollectionTask
{
    internal class Program
    {
        // Список
        private class ListTask
        {
            private List<string> GetRecipe()
            {
                return new List<string> { "ApplePie", "BananaPie", "CherryPie", "Donut", "Eclair" };
            }
            public void TaskLoop()

            {
                var list = GetRecipe();
                while (true)
                {
                    Console.WriteLine("Do you want to continue? Type 'yes' or 'exit' to quit");
                    string command = Console.ReadLine();
                    if (command == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    else if (command == "yes")
                    {

                        Console.WriteLine("Enter recipe to check if it is in the list:");
                        string text = Console.ReadLine();

                        if (list.Contains(text))
                        {
                            Console.WriteLine("Yes, we have this recipe.");
                        }
                        else
                        {
                            Console.WriteLine("No, we don't have this recipe.");
                            for (int i = 0; i < list.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {list[i]}");
                            }
                        }

                        Console.WriteLine("Do you want to add another recipe? 1 - Yes, 2 - No");

                        int result = int.Parse(Console.ReadLine());
                        if (result == 1)
                        {
                            Console.WriteLine("Enter the name of the recipe to add:");
                            string newRecipe = Console.ReadLine();
                            list.Add(newRecipe);
                            Console.WriteLine("Updated recipe list:");
                            for (int i = 0; i < list.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {list[i]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Thank you!");
                        }

                        Console.WriteLine("Write another recipe to insert in the middle of the list:");
                        string middleRecipe = Console.ReadLine();
                        int middleIndex = list.Count / 2;
                        list.Insert(middleIndex, middleRecipe);

                    }
                }
            }
        }
        // Словарь
        private class DictionaryTask
        {

            private Dictionary<string, double> dictionary;

            public DictionaryTask()
            {
                dictionary = new Dictionary<string, double>
        {
            { "Mark", 3f },
            { "Dmitriy", 3f },
            { "Konstantin", 4f },
            { "Igor", 5f },
            { "Erik", 2f }
        };
            }

            public void TaskLoop()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to continue? Type 'yes' or 'exit' to quit");
                    string command = Console.ReadLine();
                    if (command == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    else if (command == "yes")
                    {
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter grade:");
                        if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 2 && grade <= 5)
                        {
                            dictionary[name] = grade;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid grade from 2 to 5.");
                            continue;
                        }

                        Console.WriteLine("Enter name to check grade:");
                        name = Console.ReadLine();

                        if (dictionary.ContainsKey(name))
                        {
                            Console.WriteLine($"Student {name} has grade {dictionary[name]}.");
                        }
                        else
                        {
                            Console.WriteLine($"Student {name} not found.");
                        }

                    }

                }
            }
        }

        // Связанный список
        private class LinkedListTask
        {
            private class Node { public string Value; public Node Next; public Node Prev; } // Узел списка

            private Node head;
            private Node tail;
            public void TaskLoop()
            {
                while (true)
                {
                    Console.WriteLine("Do you want to continue? Type 'yes' or 'exit' to quit");
                    string command = Console.ReadLine();
                    if (command == "exit")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    else if (command == "yes")
                    {
                        Console.WriteLine("Enter a length of the list, from 3 to 6:");
                        string value = Console.ReadLine();
                        if (int.TryParse(value, out int length) && length >= 3 && length <= 6)
                        {
                            head = null;
                            tail = null;
                            for (int i = 0; i < length; i++)
                            {
                                Console.WriteLine($"Enter value for node {i + 1}:");
                                string nodeValue = Console.ReadLine();
                                Node newNode = new Node { Value = nodeValue, Next = null, Prev = tail };
                                if (head == null)
                                {
                                    head = newNode;
                                }
                                if (tail != null)
                                {
                                    tail.Next = newNode;
                                }
                                tail = newNode;

                            }
                            Console.WriteLine("Forward order:");
                            Node current = head;
                            while (current != null)
                            {
                                Console.WriteLine(current.Value);
                                current = current.Next;
                            }


                            Console.WriteLine("Reverse order:");
                            Node currentRev = tail;
                            while (currentRev != null)
                            {
                                Console.WriteLine(currentRev.Value);
                                currentRev = currentRev.Prev;
                            }
                        }
                    }
                }
            }
        }
            static void Main(string[] args)
            {
                Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
                int task = int.Parse(Console.ReadLine()); // Используйте tryParse
                switch (task)
                {
                    case 1:
                        CheckTaskFirst(); // Выполнение задания в отдельном методе
                        break;
                    case 2:
                        CheckTaskSecond();
                        break;
                    case 3:
                        CheckTaskThird();
                        break;
                }
            }

            private static void CheckTaskFirst()
            {
                var listTask = new ListTask();
                listTask.TaskLoop();
            }
            private static void CheckTaskSecond()
            {
                var dictionaryTask = new DictionaryTask();
                dictionaryTask.TaskLoop();
            }
            private static void CheckTaskThird()
            {
                var linkedListTask = new LinkedListTask();
                linkedListTask.TaskLoop();
            }
        }
   
}