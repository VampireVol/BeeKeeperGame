using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairChromosome
{
    public Chromosome main;
    public Chromosome secondary;

    public PairChromosome(Chromosome main, Chromosome secondary)
    {
        this.main = main;
        this.secondary = secondary;
    }

    public Chromosome GetDominantChromosome()
    {
        if (main.isDominant())
        {
            return main;
        }
        else if (secondary.isDominant())
        {
            return secondary;
        }
        else
        {
            return main;
        }
    }

    public static PairChromosome Inherit(PairChromosome parent1, PairChromosome parent2)
    {
        Chromosome choice1;
        if (Random.value >= 0.5f)
        {
            choice1 = parent1.main;
        }
        else
        {
            choice1 = parent1.secondary;
        }

        Chromosome choice2;
        if (Random.value >= 0.5f)
        {
            choice2 = parent2.main;
        }
        else
        {
            choice2 = parent2.secondary;
        }

        var mutation = choice1.TryMutate(choice2);
        if (mutation != null)
        {
            if (Random.value >= 0.5f)
            {
                choice1 = mutation;
            }
            else
            {
                choice2 = mutation;
            }
        }

        if (Random.value >= 0.5f)
        {
            return new PairChromosome(choice1, choice2);
        }
        else
        {
            return new PairChromosome(choice2, choice1);
        }        
    }
}
