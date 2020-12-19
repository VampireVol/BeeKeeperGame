using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public List<BeeShopItem> List;
    public GameObject SlotPrefab;
    public Transform Content;
    public BeeIconDictionary iconDictionary;
    public InventoryManager inventoryManager; 

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in List)
        {
            GameObject newSlot = Instantiate(SlotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            float scaleValue = Screen.width / 1080f;
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(Content);

            SlotStore slotStore = newSlot.GetComponent<SlotStore>();
            slotStore.SetUp($"{item.ValueType} {item.BeeType}", iconDictionary.GetSprites(item.ValueType)[(int)item.BeeType], this);
        }
    }

    public void TryAddItemInInventory(int index)
    {
        Debug.Log($"Chose butn: {index}");
        inventoryManager.AddBee(new Bee(AlleleDictionary.GetAllele(List[index].ValueType), List[index].BeeType));
    }
}
