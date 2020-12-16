using System.Collections;
using UnityEngine;

public abstract class Chromosome
{
    public int value;
    public bool dominant;

    protected Chromosome(int value, bool dominant)
    {
        this.value = value;
        this.dominant = dominant;
    }

    public override bool Equals(object obj)
    {
        return obj is Chromosome chromosome &&
               value == chromosome.value &&
               dominant == chromosome.dominant;
    }

    public override int GetHashCode()
    {
        int hashCode = 1134590987;
        hashCode = hashCode * -1521134295 + value.GetHashCode();
        hashCode = hashCode * -1521134295 + dominant.GetHashCode();
        return hashCode;
    }

    public bool isDominant()
    {
        return dominant;
    }

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

