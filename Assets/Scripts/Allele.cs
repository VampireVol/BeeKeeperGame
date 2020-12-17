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
}

