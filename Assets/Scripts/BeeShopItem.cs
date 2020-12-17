using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BeeShopItem", menuName = "BeeShopItem")]
public class BeeShopItem : ScriptableObject
{
    public Species.ValueType ValueType;
    public int Price;
    public BeeType BeeType;
}
