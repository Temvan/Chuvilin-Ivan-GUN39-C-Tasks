namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Fibonaccy
            int a = 0;
            int b = 1;
            Console.WriteLine(a);
            Console.WriteLine(b);
            for (int i = 2; i < 10; i++)
            {
                int c = a + b;
                Console.WriteLine(c);
                a = b;
                b = c;
            }
            Console.WriteLine("-------------------");

            //Even numbers
            for (int i = 2; i <= 20; i += 2)
            {
                Console.WriteLine("Even number: " + i);
            }

            Console.WriteLine("-------------------");

            //Multiplication table

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write((i * j).ToString().PadLeft(4));
                }
                Console.WriteLine();
            }

            Console.WriteLine("-------------------");


            //Password attempt
            string password = "qwerty";
            Console.WriteLine("Enter password:");
            
            do
            {
                string input = Console.ReadLine();
                if (input != password)
                {
                    Console.WriteLine("Incorrect password. Try again:");
                }
                else
                {
                    Console.WriteLine("Access granted.");
                    break;
                }
            } while (true);



        }
        
    }
}