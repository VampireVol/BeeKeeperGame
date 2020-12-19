using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;
    //ПРЕНЕСТИ
    public StorageManager storageManager;

    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
        if (storageManager != null)
        {
            storageManager.RenderPage(this.transform.GetSiblingIndex());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEneter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    private void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

}
