using System.Collections;
using UnityEngine;

[System.Serializable]
public abstract class Chromosome
{
    public bool dominant;

    protected Chromosome(bool dominant)
    { 
        this.dominant = dominant;
    }

    public bool isDominant()
    {
        return dominant;
    }

    public abstract int GetValue();

    public virtual Chromosome Inherit(Chromosome parent)
    {
        if (Random.value > 0.5f)
        {
            return this;
        }
        else
        {
            return parent;
        }
    }

    public virtual Chromosome TryMutate(Chromosome parent)
    {
        return null;
    }
}

