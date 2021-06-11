using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationPairChromosomeInfo
{
    public Species.ValueType value;
    public bool isMain;

    public MutationPairChromosomeInfo(Species.ValueType value, bool isMain)
    {
        this.value = value;
        this.isMain = isMain;
    }
}

[System.Serializable]
public class PairChromosome
{
    public Chromosome main;
    public Chromosome secondary;

    public PairChromosome(Chromosome main, Chromosome secondary)
    {
        this.main = main;
        this.secondary = secondary;
    }

    public PairChromosome(Chromosome chromosome)
    {
        main = chromosome;
        secondary = chromosome;
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

    public bool IsMutate(PairChromosome parent1, PairChromosome parent2)
    {
        //Проверка есть ли отличие 
        if (parent1.main is Species m1 && 
            parent1.secondary is Species s1 &&
            parent2.main is Species m2 &&
            parent2.secondary is Species s2)
        {
            if ((main != m1 && main != s1 && main != m2 && main != s2) ||
                (secondary != m1 && secondary != s1 && secondary != m2 && secondary != s2))
            {
                Debug.Log("Mutation succses");
                return true;
            }
        }

        return false;
    }

    public MutationPairChromosomeInfo GetMutationInfo(PairChromosome parent1, PairChromosome parent2)
    {
        if (parent1.main is Species m1 &&
            parent1.secondary is Species s1 &&
            parent2.main is Species m2 &&
            parent2.secondary is Species s2)
        {
            if (main != m1 && main != s1 && main != m2 && main != s2)
            {
                return new MutationPairChromosomeInfo((Species.ValueType)main.GetValue(), true);
            }
            else if (secondary != m1 && secondary != s1 && secondary != m2 && secondary != s2)
            {
                return new MutationPairChromosomeInfo((Species.ValueType)secondary.GetValue(), false);
            }
        }

        Debug.LogError("[PairChromosome::GetMutateType] Mutation error!");
        return null;
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

        var mutation = choice1.TryMutate(choice2); //наверно тут мог бы и в статике тоже прописать
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
