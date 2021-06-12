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
    private static BeeIconDictionary _instance;

    public static BeeIconDictionary Instance { get { return _instance; } }

    private Dictionary<Species.ValueType, List<Sprite>> dic;

    [SerializeField]
    private List<SpeciesSprite> list;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

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