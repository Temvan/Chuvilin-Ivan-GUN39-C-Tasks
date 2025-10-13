using Collections;

var army = new List<Unit>()
{
    new Unit(){ Name = "Warrior" },
    new Unit(){ Name = "Mage" },
    new Unit(){ Name = "Archer" }
};
var order1 = new Order() { OrderValue = 1 };
var order2 = new Order() { OrderValue = 2 };
var order3 = new Order() { OrderValue = 3 };

var task1 = new TaskUnit() { Value = 1 };
var task2 = new TaskUnit() { Value = 2 };
var task3 = new TaskUnit() { Value = 3 };

Console.WriteLine("Army Units and their Abilities:");
foreach (var unit in army)
{
    Console.WriteLine($"Unit: {unit.Name}");
    Console.WriteLine("1 for Fireball, 2 for Thunderbolt, 3 for Frozenball");
    var spell = int.Parse(Console.ReadLine());
    if (unit.Abilities.TryGetValue(spell, out string ability))
    {
        Console.WriteLine($"  Ability: {ability}");
    }
    else
    {
        Console.WriteLine("  Ability not found.");
    }


    // foreach (var ability in unit.Abilities)
    // {
    //     Console.WriteLine($"  Ability {ability.Key}: {ability.Value}");
    // }
}

var orderQueue = new Queue<Order>();
orderQueue.Enqueue(order1);
orderQueue.Enqueue(order2);
orderQueue.Enqueue(order3);

var stackTask = new Stack<TaskUnit>();
stackTask.Push(task1);
stackTask.Push(task2);
stackTask.Push(task3);

while (orderQueue.Count > 0)
{
    var currentOrder = orderQueue.Dequeue();
    Console.WriteLine($"Completed task: {currentOrder.OrderValue}");
}

Console.WriteLine("Cancel task? 1 - Yes, 2 - No");
var result = int.Parse(Console.ReadLine());
if (result == 1)
{
    stackTask.Pop().Redo();
}