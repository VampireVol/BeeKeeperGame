using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome
{
    int value;
    bool dominant;
    Type type;

    Chromosome(int value, bool dominant, Type type)
    {
        this.value = value;
        this.dominant = dominant;
        this.type = type;
    }

    public bool isDominant()
    {
        return dominant;
    }
}
enum Type
{
    Species = 0,
    LifeSpan,
    Speed,
    Fertility
}

enum Speed
{
    Slowest = 0,
    Slower,
    Slow,
    Normal,
    Fast,
    Faster,
    Fastest
}

enum LifeSpan
{
    Shortest = 0,
    Shorter,
    Short,
    Normal,
    Long,
    Longer,
    Longets
}
