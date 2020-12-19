using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<SpeciesItem> listDrone;
    public List<SpeciesItem> listPrincess;

    // Start is called before the first frame update
    void Start()
    {
        listDrone = new List<SpeciesItem>();
        listPrincess = new List<SpeciesItem>();
        //var bee1 = new Bee(AlleleDictionary.GetAllele(Species.ValueType.Meadow), BeeType.Drone);
        //var bee2 = new Bee(AlleleDictionary.GetAllele(Species.ValueType.Meadow), BeeType.Drone);

        //if (bee1.Equals(bee2))
        //{
        //    Debug.Log("bee1==bee2");
        //    Debug.Log($"{bee1.GetHashCode()} {bee2.GetHashCode()}");
        //}
        //else
        //{
        //    Debug.Log("bee1!=bee2");
        //}
    }

    public void AddBee(Bee bee)
    {
        if (bee.type == BeeType.Drone)
        {
            AddBeeInList(bee, listDrone);
        }
        else if (bee.type == BeeType.Princess)
        {
            AddBeeInList(bee, listPrincess);
        }
        else
        {
            Debug.LogError("[InventoryManager] What a hell? Queen here?!");
        }        
    }

    private void AddBeeInList(Bee bee, List<SpeciesItem> list)
    {
        if (list.Count == 0)
        {
            AddItemInList(bee, list);
            return;
        }

        foreach (var item in list)
        {
            if (item.species.Equals(bee.GetSpecies()))
            {
                item.AddBee(bee);
                return;
            }
        }

        AddItemInList(bee, list);
    }

    private void AddItemInList(Bee bee, List<SpeciesItem> list)
    {
        //тут посылать проверку в биистеарий
        var beeList = new List<BeeItem>();
        var beeItem = new BeeItem(bee);
        beeList.Add(beeItem);
        var speciesItem = new SpeciesItem(beeList);
        list.Add(speciesItem);
    }
}
