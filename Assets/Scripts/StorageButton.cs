using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageButton : MonoBehaviour, IPointerClickHandler
{
    public StorageContoller storageContoller;
    public SlotStorage slotStorage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (slotStorage.icon.IsActive())
        {
            storageContoller.OnButtonSelected(this);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        storageContoller = transform.parent.gameObject.GetComponent<StorageContoller>();
        if (storageContoller == null)
            Debug.Log("SOME PROBLEM");
        storageContoller.Subscribe(this);
    }


}
