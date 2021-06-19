﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageHendler : MonoBehaviour
{
    public enum RenderState
    {
        Standart,
        SecondBarOnly,
        WithoutSecondBar,
        FullPage
    }

    public enum RenderType
    {
        SpeciesItem,
        BeeItem,
        ProductionItem,
        CombItem
    }

    [System.Serializable]
    public enum Render
    {
        DroneStorage,
        PrincesStorage,
        ProductionStorage,
        DroneStorageDescription,
        PrincesStorageDescription,
        ProductionStorageDescription
    }

    public void SetRenderDecision(StorageRenderDecision render)
    {

    }

    public InventoryManager inventoryManager;
    public BeeIconDictionary iconDictionary;
    public List<SlotStorage> slots;

    public GameObject slotPrefab;
    public GameObject topBar;
    public GameObject secondBar;
    public GameObject slotsArea;
    public GameObject pageCounter;
    public Transform content;

    private RenderState renderState;
    private RenderType renderType;
    private int curPage = 1;
    
    

    private const float standartWidth = 1080f;
    private const float topBarHeight = 300f;
    private const float secondBarHeight = 160f;
    private const float slotHeight = 200f;
    private const int slotsInRow = 5;

    private int maxCountSlots;
    private float scaleValue = Screen.width / standartWidth;

    private int secondBarTopPosition;
    private int secondBarDownPosition;
    private int slotsAreaTopPosition;
    private int slotsAreaDownPosition;
    private int pageCounterTopPosition;
    private int pageCounterDownPositiron;

    // Start is called before the first frame update
    void Start()
    {
        slots = new List<SlotStorage>();
        secondBarTopPosition = (int)(secondBar.transform.position.y + topBarHeight * scaleValue);
        secondBarDownPosition = (int)secondBar.transform.position.y;
        slotsAreaTopPosition = (int)(slotsArea.transform.position.y + topBarHeight * scaleValue);
        slotsAreaDownPosition = (int)slotsArea.transform.position.y;

        int maxCountRow = Mathf.FloorToInt((Screen.height / scaleValue - secondBarHeight) / slotHeight);
        maxCountSlots = maxCountRow * slotsInRow;

        var posGl = pageCounter.transform.position;

        posGl.y = (Screen.height / scaleValue - topBarHeight - secondBarHeight - (maxCountRow - 2) * slotHeight) * scaleValue / 2;
        pageCounter.transform.position = posGl;

        pageCounterDownPositiron = (int)pageCounter.transform.position.y;
        pageCounterTopPosition = (int)(Screen.height / scaleValue - secondBarHeight - 2 * slotHeight - 60);
        Debug.Log(pageCounterDownPositiron);

        for (int i = 0; i < maxCountSlots; ++i)
        {
            GameObject newSlot = Instantiate(slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            slots.Add(slotStorage);
        }
    }

    public void RenderSpeciesDroneStorage()
    {
        SetDefaultPosition();
        int countSlots = maxCountSlots - 10;
        var list = inventoryManager.listDrone;
        SetupSpeciesItem(list, countSlots);
        ActivateSlots(countSlots);
    }
    public void RenderSpeciesDroneStorageDescription(int choiceIndex)
    {
        SetDescriptionPosition();
        int countSlots = 10;
        var list = inventoryManager.listDrone;
        SetupSpeciesItem(list, countSlots);
        ActivateSlots(countSlots);
    }
    public void RenderDroneStorage(int speciesItemIndex)
    {
        SetDefaultPosition();
        int countSlots = maxCountSlots - 10;
        var list = inventoryManager.listDrone[speciesItemIndex].list;
        SetupBeeItem(list, countSlots, speciesItemIndex);
        ActivateSlots(countSlots);
    }
    public void RenderDroneStorageDescription(int speciesItemIndex, int choiceIndex)
    {
        SetDescriptionPosition();
        int countSlots = 10;
        var list = inventoryManager.listDrone[speciesItemIndex].list;
        SetupBeeItem(list, countSlots, speciesItemIndex);
    }

    public void RenderSpeciesPrincesStorage()
    {

    }
    public void RenderSpeciesPrincesStorageDescription(int choiceIndex)
    {

    }
    public void RenderPrincesStorage(int speciesItemIndex)
    {

    }
    public void RenderPrincesStorageDescription(int speciesItemIndex, int choiceIndex)
    {

    }

    public void RenderProductionStorage()
    {

    }
    public void RenderProductionStorageDescription(int choiceIndex)
    {

    }

    private void SetDefaultPosition()
    {
        ClearAllSlots();
        topBar.SetActive(true);
        secondBar.SetActive(true);
        var position = secondBar.transform.position;
        secondBar.transform.position = new Vector3(position.x, secondBarTopPosition);
        position = slotsArea.transform.position;
        slotsArea.transform.position = new Vector3(position.x, slotsAreaTopPosition);
    }

    private void SetDescriptionPosition()
    {
        ClearAllSlots();
        topBar.SetActive(false);
        secondBar.SetActive(true);
        var position = secondBar.transform.position;
        secondBar.transform.position = new Vector3(position.x, secondBarDownPosition);
        position = slotsArea.transform.position;
        slotsArea.transform.position = new Vector3(position.x, slotsAreaDownPosition);
    }

    private void SetupSpeciesItem(List<SpeciesItem> list, int countSlots)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.species)[(int)item.beeType];
            slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.SpeciesItem, item, item.beeType);
        }
        ActivateSlots(countSlots);
    }

    private void SetupBeeItem(List<BeeItem> list, int countSlots, int speciesItemIndex)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, speciesItemIndex);
        }
        ActivateSlots(countSlots);
    }

    private void ActivateSlots(int count)
    {
        for (int i = 0; i < count; ++i)
            slots[i].transform.gameObject.SetActive(true);
    }

    public void SetRenderState(int index)
    {
        renderState = (RenderState)index;
        SetObjectPositon();
        //start render func
    }

    public void SetRenderType(int index)
    {
        renderType = (RenderType)index;
        //start render func
    }

    public void SetRenderStateAndRenderType(int state, int type)
    {
        renderState = (RenderState)state;
        renderType = (RenderType)type;
        //start render func
    }

    private void SetObjectPositon()
    {
        int countSlots = 0;
        int countRow = 0;
        if (renderState == RenderState.Standart)
        {
            //back position!!!!
            countRow = Mathf.FloorToInt((Screen.height / scaleValue - topBarHeight - secondBarHeight) / slotHeight);
            countSlots = countRow * slotsInRow;
        }
        else if (renderState == RenderState.SecondBarOnly)
        {

            topBar.SetActive(false);
            var pos = secondBar.transform.position;
            secondBar.transform.position = new Vector3(pos.x, secondBarTopPosition, pos.z);
            pos = slotsArea.transform.position;
            slotsArea.transform.position = new Vector3(pos.x, slotsAreaTopPosition, pos.z);
            pos = pageCounter.transform.position;
            pageCounter.transform.position = new Vector3(pos.x, pageCounterTopPosition, pos.z);
            countSlots = 10;
        }
        else if (renderState == RenderState.FullPage)
        {
            countRow = Mathf.FloorToInt((Screen.height / scaleValue - secondBarHeight) / slotHeight);
            topBar.SetActive(false);
            secondBar.SetActive(false);
            content.position = new Vector3(0f, content.position.y - topBarHeight * scaleValue, 0f);
            countSlots = countRow * slotsInRow;
        }
    }

    //Execute from Inspector (no may be)
    public void RenderPageSlots(int index, int i1, int i2)
    {
        //temp
        int countSlots = 10;

        var state = (RenderState) index;
        renderState = state;
        SetObjectPositon();

        Debug.Log(i1);
        ClearAllSlots();
        var list = inventoryManager.listDrone[i2].list;
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, i2);
        }
        content.gameObject.SetActive(true);
        for (int i = 0; i < countSlots; ++i)
        {
            slots[i].transform.gameObject.SetActive(true);
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
                slot.transform.gameObject.SetActive(true);
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
        Debug.Log(countSlots);
        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];

            Sprite sprite = iconDictionary.GetSprites(item.species)[(int)item.beeType];
            slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.SpeciesItem, item, item.beeType);
        }

        for (int i = 0; i < slots.Count - 10; ++i)
        {
            slots[i].transform.gameObject.SetActive(true);
        }        
    }

    private void RenderPage(List<BeeItem> list, int indexSp)
    {
        int countSlots = list.Count / 5;
        countSlots = countSlots * 5 + 5;
        int countHaveSlots = slots.Count;

        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, indexSp);
        }

        for (int i = 0; i < countSlots; ++i)
        {
            slots[i].transform.gameObject.SetActive(true);
        }
    }

    private void ClearAllSlots()
    {
        foreach (var slot in slots)
        {
            slot.Clear();
            slot.transform.gameObject.SetActive(false);
        }
    }
}