namespace OOP
{
    class Program
    {
        // public abstract class Animal
        // {
        //     private object _model;

        //     protected Animal(object model)
        //     {
        //         _model = model;
        //     }
        //     protected abstract string Name { get; }
        //     public abstract void Move();
        //     public abstract void Jump();

        //     public virtual void MakeSound() { }

        //     public object GetModel() => _model;

        //     protected override void CalculateMove();
            
        // }
        // public sealed class Cat : Animal
        // {
        //     public string Name => "Stray";

        //     private readonly Random _random = new Random();

        //     public Cat(object model) : base(model) { }
        //     protected override string Name = "Stray";

        //     private bool CanJump(int jumpThreshold) => jumpThreshold > 5;
            

        //     public override void Move() => CalculateMove();
            
        //     public void Jump()
        //     {
        //         int randomHeight = _random.Next(1, 10);
        //         if (CanJump(randomHeight))
        //         {
        //              Console.WriteLine($"The {Name} is jumping.");
        //         }
        //         else
        //         {
        //             Meow();
        //             Console.WriteLine($"The {Name} couldn't jump that high.");
        //         }
        //     }
        //     private void Meow()
        //     {
        //         Console.WriteLine("Meow!");
        //     }

        //     protected override void CalculateMove()
        //     {
        //         Console.WriteLine($"{Name} moved");
        //     }

        //     public override void MakeSound()
        //     {
        //         Meow();
        //     }

        //     private class BritishCat : Cat {}
        // }
        static void Main(string[] args)
        {
            // var cat = new Cat(new object());
            // cat.Move();
            // cat.Jump();
            // cat.MakeSound();

            int variable1 = 10;
            float variable2 = variable1 + 0.6f;
            short variable3 = (short)variable2;
            Console.WriteLine($"Var 1 = {variable1} Var 2 = {variable2} Var 3 = {variable3}");
        }
    }
}