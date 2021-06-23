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

    private Dictionary<Species.ValueType, List<Sprite>> _dictionary;

    [SerializeField]
    private List<SpeciesSprite> _list;

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

        _dictionary = new Dictionary<Species.ValueType, List<Sprite>>();
        foreach (var item in _list)
        {
            _dictionary.Add(item.value, new List<Sprite>()
            {
                item.drone,
                item.princess,
                item.queen
            });
        }
    }

    public List<Sprite> GetSprites(Species.ValueType value)
    {
        try 
        {
            return _dictionary[value];
        }
        catch (KeyNotFoundException)
        {
            Debug.LogError($"[BeeIconDictionary] icon for {value} is null");
            return null;
        }
    }
}