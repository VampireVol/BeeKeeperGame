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
    public GameObject topBar;
    public GameObject secondBar;
    public GameObject slotArea;
    public Transform content;
    

    public enum RenderState
    {
        Standart,
        SecondBarOnly,
        WithoutSecondBar,
        FullPage
    }

    private const float standartWidth = 1080f;
    private const float topBarHeight = 300f;
    private const float secondBarHeight = 160f;
    private const float slotHeight = 200f;
    private const int slotsInRow = 5;
    
    private float scaleValue = Screen.width / standartWidth;

    private int secondBarTopPosition;
    private int secondBarDownPosition;
    private int slotsAreaTopPosition;
    private int slotsAreaDownPosition;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<SlotStorage>();
        secondBarTopPosition = (int)(secondBar.transform.position.y + topBarHeight * scaleValue);
        secondBarDownPosition = (int)secondBar.transform.position.y;
        slotsAreaTopPosition = (int)(slotArea.transform.position.y + topBarHeight * scaleValue);
        slotsAreaDownPosition = (int)slotArea.transform.position.y;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescription(int indexSpecies, int indexBee)
    {

    }

    //Execute from Inspector
    public void RenderPageSlots(int index, int i1, int i2)
    {
        int countSlots = 0;
        int countRow = 0;
        var state = (RenderState) index;
        
        if (state == RenderState.Standart)
        {
            countRow = Mathf.FloorToInt((Screen.height / scaleValue - topBarHeight - secondBarHeight) / slotHeight);
            countSlots = countRow * slotsInRow;
        }
        else if (state == RenderState.SecondBarOnly)
        {
            topBar.SetActive(false);
            var pos = secondBar.transform.position;
            secondBar.transform.position = new Vector3(pos.x, secondBarTopPosition, pos.z);
            pos = slotArea.transform.position;
            slotArea.transform.position = new Vector3(pos.x, slotsAreaTopPosition, pos.z);
            countSlots = 10;
        }
        else if (state == RenderState.FullPage)
        {
            countRow = Mathf.FloorToInt((Screen.height / scaleValue - secondBarHeight) / slotHeight);
            topBar.SetActive(false);
            secondBar.SetActive(false);
            content.position = new Vector3(0f, content.position.y - topBarHeight * scaleValue, 0f);
            countSlots = countRow * slotsInRow;
        }
        int countHaveSlots = slots.Count;
        for (int i = 0; i < countSlots - countHaveSlots; ++i)
        {
            GameObject newSlot = Instantiate(slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            slots.Add(slotStorage);
        }

        ClearAllSlots();
        var list = inventoryManager.listDrone[i1].list;
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            slots[i].Setup(sprite, item.count, this, item.bee.type, i1);
        }
        content.gameObject.SetActive(true);
        for (int i = 0; i < countSlots; ++i)
        {
            slots[i].transform.parent.gameObject.SetActive(true);
        }
    }

    //Execute from Inspector
    public void RenderPage(int index)
    {
        if (index == 0)
        {
            RenderPage(inventoryManager.listPrincess);
            //Debug.Log("prin");
        }
        else if (index == 1)
        {
            RenderPage(inventoryManager.listDrone);
            //Debug.Log("drone");
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
