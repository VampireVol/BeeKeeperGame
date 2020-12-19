using System.Collections.Generic;
using UnityEngine;

public class AlleleDictionary : MonoBehaviour
{
    [System.Serializable]
    private class SpeciesAllele
    {
        public Species.ValueType key;
        public Allele value;
    }

    private static Dictionary<Species.ValueType, Allele> KeyValues;

    [SerializeField]
    private List<SpeciesAllele> list;

    private void Awake()
    {
        KeyValues = new Dictionary<Species.ValueType, Allele>();
        Debug.Log("Awake Start");
        foreach (var item in list)
        {
            KeyValues.Add(item.key, item.value);
        }
    }

    public AlleleDictionary()
    {
        Debug.Log("Constr start");
        if (KeyValues != null)
        {
            Debug.LogError("[AlleleDictionary] Dictionary already exist!");
            KeyValues = new Dictionary<Species.ValueType, Allele>();
            Init();
        }            
    }

    public static Allele GetAllele(Species.ValueType value)
    {
        return KeyValues[value];
    }

    private void Init()
    {
        /*AddAllele(new Species(Species.ValueType.Meadow, false),
            new Speed(Speed.ValueType.Slowest, false),
            new LifeSpan(LifeSpan.ValueType.Short, false),
            new Fertility(2, false));

        AddAllele(new Species(Species.ValueType.River, false),
            new Speed(Speed.ValueType.Slower, false),
            new LifeSpan(LifeSpan.ValueType.Shorter, false),
            new Fertility(2, false));

        AddAllele(new Species(Species.ValueType.Steppe, false),
            new Speed(Speed.ValueType.Slowest, false),
            new LifeSpan(LifeSpan.ValueType.Shorter, false),
            new Fertility(2, false));

        AddAllele(new Species(Species.ValueType.Plant, false),
            new Speed(Speed.ValueType.Normal, false),
            new LifeSpan(LifeSpan.ValueType.Shortest, false),
            new Fertility(3, true));

        AddAllele(new Species(Species.ValueType.Vegetable, false),
            new Speed(Speed.ValueType.Slowest, false),
            new LifeSpan(LifeSpan.ValueType.Normal, false),
            new Fertility(2, false));

        AddAllele(new Species(Species.ValueType.Tomato, false),
            new Speed(Speed.ValueType.Fast, false),
            new LifeSpan(LifeSpan.ValueType.Shortest, false),
            new Fertility(2, false));*/
    }

    private void AddAllele(Species species, Speed speed, LifeSpan lifeSpan, Fertility fertility)
    {
        KeyValues.Add((Species.ValueType)species.value, new Allele(species, speed, lifeSpan, fertility));
    }
}

