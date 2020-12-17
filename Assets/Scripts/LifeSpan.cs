[System.Serializable]
public class LifeSpan : Chromosome
{
    public ValueType value;

    public LifeSpan(ValueType value)
        : base(false)
    {
        this.value = value;
    }

    public LifeSpan(ValueType value, bool dominant) 
        : base(dominant)
    {
        this.value = value;
    }

    public override int GetValue()
    {
        return (int)value;
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

