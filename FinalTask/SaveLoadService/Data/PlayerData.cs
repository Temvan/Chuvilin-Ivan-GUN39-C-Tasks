namespace FinalTask
{
    [System.Serializable]
public struct PlayerData : IData
    {
        public readonly string Name;
        public readonly int Age;
        public int Bank { get; private set;}
        
        public PlayerData(string name, int age, int bank)
        {
            Name = name;
            Age = age;
            Bank = bank;
        }

        public void UpdateBank(in int money)
        {
            Bank = money;
        }
        public void IncreaseBank(in int money)
        {
            Bank += money;
        }
        public void DecreaseBank(in int money)
        {
            Bank -= money;
        }
    }    
    public interface IData
    {
        
    }
    public class EnemyData : IData
    {
        public readonly string Name;
        public readonly int Age;
        public int Bank { get; private set; }

        public EnemyData(string name, int age, int bank)
        {
            Name = name;
            Age = age;
            Bank = bank;
        }
    }

}