using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<BeeShopItem> List;
    public GameObject SlotPrefab;
    public Transform Content;
    public BeeIconDictionary iconDictionary;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in List)
        {
            GameObject newSlot = Instantiate(SlotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newSlot.transform.SetParent(Content);

            SlotStore slotStore = newSlot.GetComponent<SlotStore>();
            slotStore.SetUp($"{item.ValueType} {item.BeeType}", iconDictionary.GetSprites(item.ValueType)[(int)item.BeeType]);
        }
    }
}
