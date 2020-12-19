using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotStore : MonoBehaviour
{
    public Text NameText;
    public Image Icon;
    public Button button;

    private ShopManager shopManager;

    private void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void SetUp(string name, Sprite sprite, ShopManager shopManager)
    {
        NameText.text = name;
        Icon.sprite = sprite;
        this.shopManager = shopManager;
    }

    public void HandleClick()
    {
        shopManager.TryAddItemInInventory(transform.GetSiblingIndex());
    }
}
