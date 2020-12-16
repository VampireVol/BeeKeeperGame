public class Speed : Chromosome
{
    public Speed(ValueType value, bool dominant) 
        : base((int)value, dominant)
    {

    }

    public enum ValueType
    {
        Slowest = 0,
        Slower,
        Slow,
        Normal,
        Fast,
        Faster,
        Fastest
    }
}

