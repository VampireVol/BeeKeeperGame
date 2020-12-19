using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeItem
{
    public Bee bee;
    public int count;

    public BeeItem(Bee bee)
    {
        this.bee = bee;
        count = 1;
    }

    public void AddBee()
    {
        ++count;
    }
}
