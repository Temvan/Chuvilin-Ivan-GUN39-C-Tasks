namespace Memory;

public struct Interval
{
    private static readonly Random Random = new Random();
    public int Min { get; }
    public int Max { get; }
    public int Get => Random.Next(Min, Max + 1);

    public Interval(int minValue, int maxValue)
    {

        if (minValue > maxValue)
        {
            int value = minValue;
            minValue = maxValue;
            maxValue = value;
            Console.WriteLine("Min cannot be greater than Max. Setting Min to Max value.");
        }
        if (minValue < 0)
        {
            minValue = 0;
            Console.WriteLine("Min and Max cannot be less than zero. Setting Min to zero.");
        }

        if (maxValue < 0)
        {
            maxValue = 0;
            Console.WriteLine("Min and Max cannot be less than zero. Setting Max to zero.");
        }

        if (minValue == maxValue)
        {
            maxValue += 10;
            Console.WriteLine("Min and Max cannot be equal. Increasing Max by 10.");
        }

        Min = minValue;
        Max = maxValue;
      
    }

}