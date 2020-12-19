using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesItem
{
    public List<BeeItem> list;
    public Species.ValueType species;
    public int count;
    public BeeType beeType;

    public SpeciesItem(List<BeeItem> list)
    {
        this.list = list;
        count = 1;
        if (list.Count > 0)
        {
            species = list[0].bee.GetSpecies();
            beeType = list[0].bee.type;
        }
        else
        {
            Debug.LogError("[SpeciesItem] Empty list!");
        }
        
    }

    private void AddBee()
    {
        ++count;
    }

    public void AddBee(Bee bee)
    {
        foreach (var item in list)
        {
            if (item.bee.Equals(bee))
            {
                AddBee();
                item.AddBee();
                list.Sort((x, y) => -x.count.CompareTo(y.count));
                return;
            }
        }

        AddBee();
        AddItem(bee);
    }

    private void AddItem(Bee bee)
    {
        //проверка в биистеарий
        var beeItem = new BeeItem(bee);
        list.Add(beeItem);
    }
}
