using System.Collections.Generic;
using UnityEngine;

public class SpeciesDictionary
{
    public struct MutationInfo
    {
        public readonly Species.ValueType SecondSpecies;
        public readonly float Chance;
        public readonly Species.ValueType Result;

        public MutationInfo(Species.ValueType secondSpecies, float chance, Species.ValueType result)
        {
            SecondSpecies = secondSpecies;
            Chance = chance;
            Result = result;
        }
    }

    private static Dictionary<Species.ValueType, List<MutationInfo>> KeyValues;

    public SpeciesDictionary()
    {
        if (KeyValues != null)
            Debug.LogError("[SpeciesDictionary] Dictionary already exist!");
        KeyValues = new Dictionary<Species.ValueType, List<MutationInfo>>();
        Init();
    }

    /// <summary>
    /// Returns MutationInfo
    /// </summary>
    /// <param name="type"></param>
    /// <returns>can return null</returns>
    public static List<MutationInfo> GetMutationInfo(Species.ValueType type)
    {
        List<MutationInfo> list;
        if (KeyValues.TryGetValue(type, out list))
        {
            return list;
        }
        else
        {
            Debug.LogError("[SpeciesDictionary] Can't find species in dictionary!");
            return null;
        }        
    }

    private void Init()
    {
        AddSpecies(Species.ValueType.Meadow, Species.ValueType.River, 0.4f, Species.ValueType.Plant);
        AddSpecies(Species.ValueType.Steppe, Species.ValueType.River, 0.4f, Species.ValueType.Plant);
        AddSpecies(Species.ValueType.Meadow, Species.ValueType.Plant, 0.5f, Species.ValueType.Vegetable);
        AddSpecies(Species.ValueType.Vegetable, Species.ValueType.Plant, 0.3f, Species.ValueType.Tomato);
    }

    private void AddSpecies(Species.ValueType first, Species.ValueType second, float chance, Species.ValueType result)
    {
        if (!KeyValues.ContainsKey(first))
        {
            var list = new List<MutationInfo>();
            list.Add(new MutationInfo(second, chance, result));
            KeyValues.Add(first, list);
        }
        else
        {
            var list = KeyValues[first];
            list.Add(new MutationInfo(second, chance, result));
        }

        if (!KeyValues.ContainsKey(second))
        {
            var list = new List<MutationInfo>();
            list.Add(new MutationInfo(first, chance, result));
            KeyValues.Add(second, list);
        }
        else
        {
            var list = KeyValues[second];
            list.Add(new MutationInfo(first, chance, result));
        }
    }
}

