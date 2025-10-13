namespace Collections
{
    internal class Unit
    {
        public string Name { get; set; }
        public Dictionary<int, string> Abilities = new Dictionary<int, string>() 
        {
            {1, "Fireball" },
            {2, "Thunderbolt" },
            {3, "Frozenball" }
        };
  }
}