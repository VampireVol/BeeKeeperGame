using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsBar : MonoBehaviour
{
    [SerializeField]
    List<GameObject> buttons = new List<GameObject>();
    [SerializeField]
    List<GameObject> beehivesButtons = new List<GameObject>();
    [SerializeField]
    List<GameObject> storageButtons = new List<GameObject>();
    [SerializeField]
    List<GameObject> storeButtons = new List<GameObject>();
    [SerializeField]
    List<GameObject> beestearyButtons = new List<GameObject>();


    Color active = new Color32(189, 195, 199, 255);
    Color inactive = new Color32(55, 65, 64, 255);
    //(189, 195, 199)

    private void Start()
    {
        buttons[0].GetComponent<Image>().color = active;
        beehivesButtons[0].GetComponent<Image>().color = active;
        storageButtons[1].GetComponent<Image>().color = active;
        storeButtons[0].GetComponent<Image>().color = active;
        beestearyButtons[0].GetComponent<Image>().color = active;
    }

    public void SetActiveButton (int choice)
    {
        foreach(var button in buttons) 
        {
            button.GetComponent<Image>().color = inactive;
        }
        buttons[choice].GetComponent<Image>().color = active;
    }

    public void SetActiveBeehiveButton (int choice)
    {
        foreach (var button in beehivesButtons)
        {
            button.GetComponent<Image>().color = inactive;
        }
        beehivesButtons[choice].GetComponent<Image>().color = active;
    }

}
