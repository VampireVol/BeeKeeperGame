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
            if (button.slotStorage.count.text == "1")
            {
                descriptionManager.Show(button.transform.GetSiblingIndex(), 0, button.slotStorage.beeType, button.slotStorage.count.text);
            }
            else
            {
                storageManager.RenderBeeItemsPage(button.transform.GetSiblingIndex(), button.slotStorage.beeType);
            }
        }
        else
        {
            descriptionManager.Show(button.slotStorage.indexSpecies, button.transform.GetSiblingIndex(), button.slotStorage.beeType, button.slotStorage.count.text);
        }
    }
}
