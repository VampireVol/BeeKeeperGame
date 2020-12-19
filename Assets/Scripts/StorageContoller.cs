using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContoller : MonoBehaviour
{
    public List<StorageButton> storageButtons;
    public DescriptionManager descriptionManager;
    public StorageManager storageManager;


    public void Subscribe(StorageButton button)
    {
        if (storageButtons == null)
        {
            storageButtons = new List<StorageButton>();
        }

        storageButtons.Add(button);
    }

    public void OnButtonSelected(StorageButton button)
    {
        if (button.slotStorage.indexSpecies == -1)
        {
            storageManager.RenderBeeItemsPage(button.transform.GetSiblingIndex(), button.slotStorage.beeType);
            //show и сюда
        }
        else
        {
            descriptionManager.Show(button.slotStorage.indexSpecies, button.transform.GetSiblingIndex(), button.slotStorage.beeType, button.slotStorage.count.text);
        }
    }
}
