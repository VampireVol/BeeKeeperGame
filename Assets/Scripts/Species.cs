using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Species : Chromosome
{
    public ValueType value;

    public Species(ValueType value)
        : base(false)
    {
        this.value = value;
    }

    public Species(ValueType value, bool dominant)
        : base(dominant)
    {
        this.value = value;
    }

    public enum ValueType
    {
        Meadow = 0,
        Steppe,
        Forest,
        Taiga,
        River,
        Plant,
        Vegetable,
        Tomato,
        Potato,
        Cucumber,
        Wheat
    }

    public override Chromosome Inherit(Chromosome parent)
    {
        List<SpeciesDictionary.MutationInfo> list = SpeciesDictionary.GetMutationInfo((ValueType)value);
        if (list != null)
        {
            var val = (ValueType)parent.GetValue();
            foreach (var item in list)
            {
                if (item.SecondSpecies == val)
                {
                    if (Random.value <= item.Chance)
                    {
                        return AlleleDictionary.GetAllele(item.Result).species;
                    }
                }
            }
        }
        return base.Inherit(parent);
    }

    public override Chromosome TryMutate(Chromosome parent)
    {
        List<SpeciesDictionary.MutationInfo> list = SpeciesDictionary.GetMutationInfo((ValueType)value);
        if (list != null)
        {
            var val = (ValueType)parent.GetValue();
            foreach (var item in list)
            {
                if (item.SecondSpecies == val)
                {
                    if (Random.value <= item.Chance)
                    {
                        return AlleleDictionary.GetAllele(item.Result).species;
                    }
                }
            }
        }
        return base.TryMutate(parent);
    }

    public override int GetValue()
    {
        return (int)value;
    }
}

