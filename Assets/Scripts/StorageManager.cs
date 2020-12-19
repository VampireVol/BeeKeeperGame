using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public BeeIconDictionary iconDictionary;
    public List<SlotStorage> slots;

    public GameObject slotPrefab;
    public Transform content;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<SlotStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescription(int indexSpecies, int indexBee)
    {

    }

    public void RenderPage(int index)
    {
        if (index == 0)
        {
            RenderPage(inventoryManager.listPrincess);
            Debug.Log("prin");
        }
        else if (index == 1)
        {
            RenderPage(inventoryManager.listDrone);
            Debug.Log("drone");
        }
        else
        {
            ClearAllSlots();
            foreach (var slot in slots)
            {
                slot.transform.parent.gameObject.SetActive(true);
            }
        }
    }

    public void RenderBeeItemsPage(int index, BeeType beeType)
    {
        Debug.Log($"{inventoryManager.listDrone.Count} {index}");
        if (beeType == BeeType.Drone)
        {
            RenderPage(inventoryManager.listDrone[index].list, index);
        }
        else if (beeType == BeeType.Princess)
        {
            RenderPage(inventoryManager.listPrincess[index].list, index);
        }
    }

    private void RenderPage(List<SpeciesItem> list)
    {
        int countSlots = list.Count / 5 + 5;
        int countHaveSlots = slots.Count;

        for (int i = 0; i < countSlots - countHaveSlots; ++i)
        {
            GameObject newSlot = Instantiate(slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            float scaleValue = Screen.width / 1080f;
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            slots.Add(slotStorage);
        }

        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];

            Sprite sprite = iconDictionary.GetSprites(item.species)[(int)item.beeType];
            slots[i].Setup(sprite, item.count, this, item.beeType);
        }

        for (int i = 0; i < countSlots; ++i)
        {
            slots[i].transform.parent.gameObject.SetActive(true);
        }
    }

    private void RenderPage(List<BeeItem> list, int indexSp)
    {
        int countSlots = list.Count / 5;
        countSlots = countSlots * 5 + 5;
        int countHaveSlots = slots.Count;

        for (int i = 0; i < countSlots - countHaveSlots; ++i)
        {
            GameObject newSlot = Instantiate(slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            float scaleValue = Screen.width / 1080f;
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            slots.Add(slotStorage);
        }

        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            slots[i].Setup(sprite, item.count, this, item.bee.type, indexSp);
        }

        for (int i = 0; i < countSlots; ++i)
        {
            slots[i].transform.parent.gameObject.SetActive(true);
        }
    }

    private void ClearAllSlots()
    {
        foreach (var slot in slots)
        {
            slot.Clear();
            slot.transform.parent.gameObject.SetActive(false);
        }
    }
}
