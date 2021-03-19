using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BeeType
{
    Drone = 0,
    Princess,
    Queen
}

public class Bee
{
    public List<PairChromosome> pairs;
    public BeeType type;

    public Bee (Allele allele, BeeType beeType)
    {
        type = beeType;
        pairs = new List<PairChromosome>();

        pairs.Add(new PairChromosome(allele.species));
        pairs.Add(new PairChromosome(allele.speed));
        pairs.Add(new PairChromosome(allele.lifeSpan));
        pairs.Add(new PairChromosome(allele.fertility));
    }

    public Bee(Bee parent1, Bee parent2, BeeType beeType)
    {
        type = beeType;
        pairs = Inherit(parent1.pairs, parent2.pairs);
    }

    public int GetFertility()
    {
        return pairs[3].main.GetValue();
    }

    public override bool Equals(object obj)
    {
        if (obj is Bee bee)
        {
            for (int i = 0; i < pairs.Count; ++i)
            {
                if (pairs[i].main.GetValue() != bee.pairs[i].main.GetValue() ||
                    pairs[i].secondary.GetValue() != bee.pairs[i].secondary.GetValue() )
                {
                    return false;
                }
                
            }
            if (type != bee.type)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        Debug.Log("[Bee] You Equals not bee, lol");

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public Species.ValueType GetSpecies()
    {
        return (Species.ValueType)pairs[0].main.GetValue();
    }

    private List<PairChromosome> Inherit(List<PairChromosome> parent1, List<PairChromosome> parent2)
    {
        var list = new List<PairChromosome>();
        for (int i = 0; i < parent1.Count; ++i)
        {
            var item = PairChromosome.Inherit(parent1[i], parent2[i]);
            list.Add(item);
        }

        if (list[0].IsMutate(parent1[0], parent2[0]))
        {
            var mutationInfo = list[0].GetMutationInfo(parent1[0], parent1[0]);
            SetAllele(list, AlleleDictionary.GetAllele(mutationInfo.value), mutationInfo.isMain);
        }

        return list;
    }

    private void SetAllele(List<PairChromosome> list, Allele allele, bool isMain)
    {
        var alleleList = allele.GetList();
        for (int i = 0; i < list.Count; ++i)
        {
            if (isMain)
            {
                list[i].main = alleleList[i];
            }
            else
            {
                list[i].secondary = alleleList[i]; 
            }            
        }        
    }
}