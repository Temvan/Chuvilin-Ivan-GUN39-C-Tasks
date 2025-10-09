namespace Memory;

public struct Room
{
    public Unit Unit { get; private set; }
    public Weapon Weapon { get; private set; } 
   
    public Room(Unit unit, Weapon weapon)
    {
        Unit = unit;
        Weapon = weapon;
    }
 }