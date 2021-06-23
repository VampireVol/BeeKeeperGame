using System.Collections;
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

    [SerializeField] private InventoryManager _inventoryManager;
    //Заменить на одиночку
    [SerializeField] private BeeIconDictionary _iconDictionary;
    private List<SlotStorage> _slots;

    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private GameObject _topBar;
    [SerializeField] private GameObject _secondBar;
    [SerializeField] private GameObject _slotsArea;
    [SerializeField] private GameObject _pageCounter;
    [SerializeField] private Transform _content;

    private RenderState renderState;
    private RenderType renderType;
    private int _curPage = 1;
    private int _maxPage;



    private const float StandartWidth = 1080f;
    private const float TopBarHeight = 300f;
    private const float SecondBarHeight = 160f;
    private const float PageCounterHeight = 120f;
    private const float SlotHeight = 200f;
    private const int SlotsInRow = 5;

    private int _maxCountSlots;
    private int _curCountSlots;
    private float _scaleValue = Screen.width / StandartWidth;

    private int _secondBarTopPosition;
    private int _secondBarDownPosition;
    private int _slotsAreaTopPosition;
    private int _slotsAreaDownPosition;
    private int _pageCounterTopPosition;
    private int _pageCounterDownPositiron;

    // Start is called before the first frame update
    void Start()
    {
        _slots = new List<SlotStorage>();
        _secondBarTopPosition = (int)(_secondBar.transform.position.y + TopBarHeight * _scaleValue);
        _secondBarDownPosition = (int)_secondBar.transform.position.y;
        _slotsAreaTopPosition = (int)(_slotsArea.transform.position.y + TopBarHeight * _scaleValue);
        _slotsAreaDownPosition = (int)_slotsArea.transform.position.y;

        int maxCountRow = Mathf.FloorToInt((Screen.height / _scaleValue - SecondBarHeight) / SlotHeight);
        _maxCountSlots = maxCountRow * SlotsInRow;

        var posGl = _pageCounter.transform.position;

        posGl.y = (Screen.height / _scaleValue - TopBarHeight - SecondBarHeight - (maxCountRow - 2) * SlotHeight) * _scaleValue / 2;
        _pageCounter.transform.position = posGl;

        _pageCounterDownPositiron = (int)_pageCounter.transform.position.y;
        _pageCounterTopPosition = (int)(Screen.height / _scaleValue - SecondBarHeight - 2 * SlotHeight - 60);
        Debug.Log(_pageCounterDownPositiron);

        for (int i = 0; i < _maxCountSlots; ++i)
        {
            GameObject newSlot = Instantiate(_slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Vector3 scale = new Vector3(_scaleValue, _scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(_content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            _slots.Add(slotStorage);
        }
    }

    public void RecalcPage(int newCountSlots, int choiceIndex = -1)
    {
        if (_curCountSlots == newCountSlots)
            return;
        //TODO: пересчет номера страницы при 10 слотах и обратно
    }

    public void NextPage()
    {
        if (_curPage == _maxPage)
            _curPage = 1;
        else
            ++_curPage;
        //TODO: вывод следующей страницы при curCountSlots
    }
    public void PrevPage()
    {
        if (_curPage == 1)
            _curPage = _maxPage;
        else
            --_curPage;
        //TODO: вывод прошлой страницы при curCountSlots
    }

    public void RenderSpeciesDroneStorage()
    {
        SetDefaultPosition();
        int countSlots = _maxCountSlots - 10;
        var list = _inventoryManager.listDrone;
        SetupSpeciesItem(list, countSlots);
        ActivateSlots(countSlots);
    }
    public void RenderSpeciesDroneStorageDescription(int choiceIndex)
    {
        SetDescriptionPosition();
        int countSlots = 10;
        var list = _inventoryManager.listDrone;
        SetupSpeciesItem(list, countSlots);
        ActivateSlots(countSlots);
    }
    public void RenderDroneStorage(int speciesItemIndex)
    {
        SetDefaultPosition();
        int countSlots = _maxCountSlots - 10;
        var list = _inventoryManager.listDrone[speciesItemIndex].list;
        SetupBeeItem(list, countSlots, speciesItemIndex);
        ActivateSlots(countSlots);
    }
    public void RenderDroneStorageDescription(int speciesItemIndex, int choiceIndex)
    {
        SetDescriptionPosition();
        int countSlots = 10;
        var list = _inventoryManager.listDrone[speciesItemIndex].list;
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
        _topBar.SetActive(true);
        _secondBar.SetActive(true);
        var position = _secondBar.transform.position;
        _secondBar.transform.position = new Vector3(position.x, _secondBarTopPosition);
        position = _slotsArea.transform.position;
        _slotsArea.transform.position = new Vector3(position.x, _slotsAreaTopPosition);
    }

    private void SetDescriptionPosition()
    {
        ClearAllSlots();
        _topBar.SetActive(false);
        _secondBar.SetActive(true);
        var position = _secondBar.transform.position;
        _secondBar.transform.position = new Vector3(position.x, _secondBarDownPosition);
        position = _slotsArea.transform.position;
        _slotsArea.transform.position = new Vector3(position.x, _slotsAreaDownPosition);
    }

    private void SetupSpeciesItem(List<SpeciesItem> list, int countSlots)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = _iconDictionary.GetSprites(item.species)[(int)item.beeType];
            _slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.SpeciesItem, item, item.beeType);
        }
        ActivateSlots(countSlots);
    }

    private void SetupBeeItem(List<BeeItem> list, int countSlots, int speciesItemIndex)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = _iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            _slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, speciesItemIndex);
        }
        ActivateSlots(countSlots);
    }

    private void UpdateMaxPageCount<T>(List<T> list, int newCountSlots)
    {
        _maxPage = Mathf.CeilToInt((float)list.Count / newCountSlots);
    }

    private void ActivateSlots(int count)
    {
        for (int i = 0; i < count; ++i)
            _slots[i].transform.gameObject.SetActive(true);
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
            countRow = Mathf.FloorToInt((Screen.height / _scaleValue - TopBarHeight - SecondBarHeight) / SlotHeight);
            countSlots = countRow * SlotsInRow;
        }
        else if (renderState == RenderState.SecondBarOnly)
        {

            _topBar.SetActive(false);
            var pos = _secondBar.transform.position;
            _secondBar.transform.position = new Vector3(pos.x, _secondBarTopPosition, pos.z);
            pos = _slotsArea.transform.position;
            _slotsArea.transform.position = new Vector3(pos.x, _slotsAreaTopPosition, pos.z);
            pos = _pageCounter.transform.position;
            _pageCounter.transform.position = new Vector3(pos.x, _pageCounterTopPosition, pos.z);
            countSlots = 10;
        }
        else if (renderState == RenderState.FullPage)
        {
            countRow = Mathf.FloorToInt((Screen.height / _scaleValue - SecondBarHeight) / SlotHeight);
            _topBar.SetActive(false);
            _secondBar.SetActive(false);
            _content.position = new Vector3(0f, _content.position.y - TopBarHeight * _scaleValue, 0f);
            countSlots = countRow * SlotsInRow;
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
        var list = _inventoryManager.listDrone[i2].list;
        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = _iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            _slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, i2);
        }
        _content.gameObject.SetActive(true);
        for (int i = 0; i < countSlots; ++i)
        {
            _slots[i].transform.gameObject.SetActive(true);
        }
    }

    //Execute from Inspector
    public void RenderPage(int index)
    {
        if (index == 0)
        {
            RenderPage(_inventoryManager.listPrincess);
            //Debug.Log("prin");
        }
        else if (index == 1)
        {
            RenderPage(_inventoryManager.listDrone);
            //Debug.Log("drone");
        }
        else
        {
            ClearAllSlots();
            foreach (var slot in _slots)
            {
                slot.transform.gameObject.SetActive(true);
            }
        }
    }

    public void RenderBeeItemsPage(int index, BeeType beeType)
    {
        Debug.Log($"{_inventoryManager.listDrone.Count} {index}");
        if (beeType == BeeType.Drone)
        {
            RenderPage(_inventoryManager.listDrone[index].list, index);
        }
        else if (beeType == BeeType.Princess)
        {
            RenderPage(_inventoryManager.listPrincess[index].list, index);
        }
    }

    private void RenderPage(List<SpeciesItem> list)
    {
        int countSlots = list.Count / 5;
        countSlots = countSlots * 5 + 5;
        int countHaveSlots = _slots.Count;

        for (int i = 0; i < countSlots - countHaveSlots; ++i)
        {
            GameObject newSlot = Instantiate(_slotPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            float scaleValue = Screen.width / 1080f;
            Vector3 scale = new Vector3(scaleValue, scaleValue);
            newSlot.transform.localScale = scale;
            newSlot.transform.SetParent(_content);

            var slotStorage = newSlot.GetComponent<SlotStorage>();
            _slots.Add(slotStorage);
        }
        Debug.Log(countSlots);
        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];

            Sprite sprite = _iconDictionary.GetSprites(item.species)[(int)item.beeType];
            _slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.SpeciesItem, item, item.beeType);
        }

        for (int i = 0; i < _slots.Count - 10; ++i)
        {
            _slots[i].transform.gameObject.SetActive(true);
        }        
    }

    private void RenderPage(List<BeeItem> list, int indexSp)
    {
        int countSlots = list.Count / 5;
        countSlots = countSlots * 5 + 5;
        int countHaveSlots = _slots.Count;

        ClearAllSlots();

        for (int i = 0; i < list.Count; ++i)
        {
            var item = list[i];
            Sprite sprite = _iconDictionary.GetSprites(item.bee.GetSpecies())[(int)item.bee.type];
            _slots[i].Setup(sprite, item.count, this, SlotStorage.ItemType.BeeItem, item, item.bee.type, indexSp);
        }

        for (int i = 0; i < countSlots; ++i)
        {
            _slots[i].transform.gameObject.SetActive(true);
        }
    }

    private void ClearAllSlots()
    {
        foreach (var slot in _slots)
        {
            slot.Clear();
            slot.transform.gameObject.SetActive(false);
        }
    }
}
