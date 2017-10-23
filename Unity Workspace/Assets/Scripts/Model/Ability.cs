using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Move {

    protected int manaCost;
    protected float magnitudeCoefficient;
    protected GameObject abilityPrefab;

    public Ability (float cooldown, string name, int manaCost, float magnitudeCoefficient, GameObject abilityPrefab) : base(cooldown,name)
    {
        this.manaCost = manaCost;
        this.abilityPrefab = abilityPrefab;
        this.magnitudeCoefficient = magnitudeCoefficient;
    }

    public int GetManaCost ()
    {
        return this.manaCost;
    }

    public void SetManaCost (int manaCost)
    {
        this.manaCost = manaCost;
    }

    public GameObject GetPrefab ()
    {
        return this.abilityPrefab;
    }

    public void SetPrefab (GameObject prefab)
    {
        this.abilityPrefab = prefab;
    }

    public float GetDmgCoefficient ()
    {
        return this.magnitudeCoefficient;
    }

    public void SetDmgCoefficient (float coefficient)
    {
        this.magnitudeCoefficient = coefficient;
    }

    public int CalculateMagnitude (int attack)
    {
        return Mathf.RoundToInt(this.magnitudeCoefficient * attack);
    }
}
