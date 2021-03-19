using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeehiveController : MonoBehaviour
{
    public Button button;
    public State state;
    public InventoryManager inventoryManager;
    public BeeIconDictionary iconDictionary;
    public Timer timer;
    public Bee bee1;
    public Bee bee2;

    public void Click()
    {
        if (state == State.Ready &&
            inventoryManager.listPrincess.Count != 0 &&
            inventoryManager.listDrone.Count != 0)
        {
            bee1 = inventoryManager.GetBee(Random.Range(0,inventoryManager.listPrincess.Count), -1,
                BeeType.Princess);
            bee2 = inventoryManager.GetBee(Random.Range(0, inventoryManager.listDrone.Count), -1,
                BeeType.Drone);
            //пихаем пчел
            timer.SetTimer(10);
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Забрать";
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.GetComponent<Image>().sprite = iconDictionary.GetSprites(bee1.GetSpecies())[(int)BeeType.Queen];
            transform.GetChild(5).gameObject.SetActive(true);
            button.interactable = false;
            state = State.Running;
        }
        else if (state == State.Running)
        {

        }
        else if (state == State.NeedGet)
        {
            inventoryManager.AddBee(new Bee(bee1, bee2, BeeType.Princess));
            for (int i = 0; i < bee1.GetFertility(); ++i)
            {
                inventoryManager.AddBee(new Bee(bee1, bee2, BeeType.Drone));
            }
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(false);
            //забираем пчел
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Начать";
            state = State.Ready;
        }
    }

    private void Update()
    {
        if (state == State.Running && !timer.isRunning())
        {
            button.interactable = true;
            state = State.NeedGet;
        }
    }

    public enum State
    {
        Ready = 0,
        Running,
        NeedGet
    }
}
