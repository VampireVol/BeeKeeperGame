using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotStorage : MonoBehaviour
{
    public Image icon;
    public Text count;
    public int indexSpecies = -1;
    public BeeType beeType;

    private StorageManager storageManager;

    public void Setup(Sprite sprite, int count, StorageManager sm, BeeType beeType, int index = -1)
    {
        icon.sprite = sprite;
        this.count.text = count.ToString();
        storageManager = sm;
        this.beeType = beeType;
        indexSpecies = index;
        icon.transform.gameObject.SetActive(true);
        this.count.transform.gameObject.SetActive(true);
    }

    public void Clear()
    {
        icon.sprite = null;
        count.text = "";
        storageManager = null;
        icon.transform.gameObject.SetActive(false);
        count.transform.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
