using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairChromosome
{
    Chromosome main;
    Chromosome secondary;

    PairChromosome(Chromosome main, Chromosome secondary)
    {
        this.main = main;
        this.secondary = secondary;
    }

    Chromosome GetDominantChromosome()
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
}
