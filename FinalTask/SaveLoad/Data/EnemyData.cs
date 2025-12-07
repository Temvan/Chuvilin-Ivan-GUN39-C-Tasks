using System.Text.Json.Serialization;

namespace FinalTask.SaveLoad.Data
{
    public class EnemyData : IData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Bank { get; set; }

        
        public EnemyData(string name, int age, int bank)
        {
            Name = name;
            Age = age;
            Bank = bank;
        }

        public void UpdateBank(int money) => Bank = money;
        public void IncreaseBank(int money) => Bank += money;
        public void DecreaseBank(int money) => Bank -= money;
    }
}
