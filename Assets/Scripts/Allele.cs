using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Allele", menuName = "Allele")]
public class Allele : ScriptableObject
{
    public Species species;
    public Speed speed;
    public LifeSpan lifeSpan;
    public Fertility fertility;

    public Allele(Species species, Speed speed, LifeSpan lifeSpan, Fertility fertility)
    {
        this.species = species;
        this.speed = speed;
        this.lifeSpan = lifeSpan;
        this.fertility = fertility;
    }

    public List<Chromosome> GetList()
    {
        var list = new List<Chromosome>();
        list.Add(species);
        list.Add(speed);
        list.Add(lifeSpan);
        list.Add(fertility);
        return list;
    }
}

