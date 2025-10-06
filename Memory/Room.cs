namespace Memory;

public struct Room
{
    public Unit Unit { get; set; }
    public Weapon Weapon { get; set; } 
   
    public Room(Unit unit, Weapon weapon)
    {
        Unit = unit;
        Weapon = weapon;
    }
 }