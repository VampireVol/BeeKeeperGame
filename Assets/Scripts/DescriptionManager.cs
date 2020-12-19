using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DescriptionArea descriptionArea;


    public void Show(int speciesIndex, int beeIndex, BeeType beeType, string count)
    {
        descriptionArea.Setup(inventoryManager.GetBee(speciesIndex, beeIndex, beeType), count);
        descriptionArea.transform.localPosition = new Vector3(0f, -650f, 0f);
        descriptionArea.transform.gameObject.SetActive(true);
    }
}
