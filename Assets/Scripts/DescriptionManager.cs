using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DescriptionArea descriptionArea;
    public GameObject scrollArea;


    public void Show(int speciesIndex, int beeIndex, BeeType beeType, string count)
    {
        descriptionArea.Setup(inventoryManager.GetBee(speciesIndex, beeIndex, beeType), count);
        descriptionArea.transform.localPosition = new Vector3(0f, 10f, 0f);
        //scrollArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 950f);
        scrollArea.transform.localPosition = new Vector3(0f, -255f, 0f);
        descriptionArea.transform.gameObject.SetActive(true);
        //StartCoroutine(SetScrollDown());
        
    }

    IEnumerator SetScrollDown ()
    {
        yield return new WaitForSeconds(0.1f);
        scrollArea.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 210f);
        scrollArea.transform.localPosition = new Vector3(0f, -625f, 0f);
    }
}
