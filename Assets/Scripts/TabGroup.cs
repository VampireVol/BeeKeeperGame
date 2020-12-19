using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Color32 tabIdle;
    public Color32 tabHover;
    public Color32 tabActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public List<GameObject> objectsToSwap2;

    private void Awake()
    {
        if (selectedTab != null)
        {
            OnTabSelected(selectedTab);
        }
    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEneter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHover;
        }        
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if (selectedTab != null)
        {
            selectedTab.Deselect();
        }

        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; ++i)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
        for (int i = 0; i < objectsToSwap2.Count; ++i)
        {
            if (i == index)
            {
                objectsToSwap2[i].SetActive(true);
            }
            else
            {
                objectsToSwap2[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
                continue;
            button.background.color = tabIdle;
        }
    }
}
