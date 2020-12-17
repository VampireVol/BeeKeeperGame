using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotStore : MonoBehaviour
{
    public Text NameText;
    public Image Icon;
    

    public void SetUp(string name, Sprite sprite)
    {
        NameText.text = name;
        Icon.sprite = sprite;
    }
}
