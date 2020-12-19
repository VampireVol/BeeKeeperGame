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
            if (item == null)
            {
                Debug.Log("IS NULL");
            }
            else
            {
                Debug.Log(slots[i].ToString());
            }

            Sprite sprite = iconDictionary.GetSprites(item.species)[(int)item.beeType];
            slots[i].Setup(sprite, item.count, this);
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
