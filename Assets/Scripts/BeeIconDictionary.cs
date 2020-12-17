using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpeciesSprite
{
    public Species.ValueType value;
    public Sprite drone;
    public Sprite princess;
    public Sprite queen;
}
public class BeeIconDictionary : MonoBehaviour
{
    private Dictionary<Species.ValueType, List<Sprite>> dic;

    [SerializeField]
    private List<SpeciesSprite> list;

    // Start is called before the first frame update
    private void Awake()
    {
        dic = new Dictionary<Species.ValueType, List<Sprite>>();
        foreach (var item in list)
        {
            dic.Add(item.value, new List<Sprite>()
            {
                item.drone,
                item.princess,
                item.queen
            });
        }
    }

    public List<Sprite> GetSprites(Species.ValueType value)
    {
        return dic[value];
    }
}