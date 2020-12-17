[System.Serializable]
public class Speed : Chromosome
{
    public ValueType value;

    public Speed(ValueType value)
        : base(false)
    {
        this.value = value;
    }

    public Speed(ValueType value, bool dominant) 
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
        Slowest = 0,
        Slower,
        Slow,
        Normal,
        Fast,
        Faster,
        Fastest
    }
}

