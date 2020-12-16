public class LifeSpan : Chromosome
{
    public LifeSpan(ValueType value, bool dominant) 
        : base((int)value, dominant)
    {

    }
    public enum ValueType
    {
        Shortest = 0,
        Shorter,
        Short,
        Normal,
        Long,
        Longer,
        Longets
    }
}

