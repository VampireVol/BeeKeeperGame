[System.Serializable]
public class Fertility : Chromosome
{
    public int value;

    public Fertility(int value)
        : base(false)
    {
        this.value = value;
    }

    public Fertility(int value, bool dominant) 
        : base(dominant)
    {

    }

    public override int GetValue()
    {
        return value;
    }
}

