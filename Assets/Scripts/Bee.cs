using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bee : ScriptableObject
{
    List<PairChromosome> pairs;
    int count;
    BeeType type;

    Image icon;
}

enum BeeType
{
    Drone = 0,
    Princess,
    Queen
}
