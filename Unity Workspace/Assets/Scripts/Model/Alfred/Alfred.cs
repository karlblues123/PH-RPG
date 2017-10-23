using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alfred : Hero {


    public override void Awake()
    {
        base.Awake();

        this.abilities = new Ability[4];

        GameObject ability1Prefab = Resources.Load<GameObject>("Prefabs/" + this.heroName + "/Mystic Pillar");
        this.abilities[0] = new Ability(20f, "Mystic Pillar", 30, 1.2f, ability1Prefab);

        GameObject ability2Prefab = Resources.Load<GameObject>("Prefabs/" + this.heroName + "/Rune Barrier");
        this.abilities[1] = new Ability(15f, "Rune Barrier", 40, 0f, ability2Prefab);

        GameObject ability3Prefab = Resources.Load<GameObject>("Prefabs/" + this.heroName + "/Arcane Overload");
        this.abilities[2] = new Ability(30f, "Arcane Overload", 50, 0.1f, ability3Prefab);

        GameObject ability4Prefab = Resources.Load<GameObject>("Prefabs/" + this.heroName + "/Arcane Storm");
        this.abilities[3] = new Ability(50f, "Arcane Storm", 90, 1f, ability4Prefab);

    }

    public override void BasicAttack()
    {
        Vector3 position = this.transform.position;
        position.x += 2f;
        GameObject bullet = basicAttackPooler.GetAvailable();
        bullet.GetComponent<Bullet>().damage = this.currentAttack;
        bullet.transform.position = position;
        bullet.SetActive(true);
    }

    public override void CastAbility1()
    {
        if(this.abilities[0].isReady())
        {
            Vector2 position = this.transform.position;
            position.x += 3f;
            position.y = -5f;
            GameObject pillar = Instantiate<GameObject>(this.abilities[0].GetPrefab(), position, this.transform.rotation);
            pillar.GetComponent<MysticPillar>().damage = this.abilities[0].CalculateMagnitude(this.currentAttack);
            this.currentMana -= this.abilities[0].GetManaCost();
            this.abilities[0].Cast();
        }
    }

    public override void CastAbility2()
    {
        if(this.abilities[1].isReady())
        {
            Vector2 position = this.transform.position;
            position.x += 2f;
            Instantiate<GameObject>(this.abilities[1].GetPrefab(), position, this.transform.rotation);
            this.currentMana -= this.abilities[1].GetManaCost();
            this.abilities[1].Cast();
        }
    }

    public override void CastAbility3()
    {
        if(this.abilities[2].isReady())
        {
            Vector2 position = this.transform.position;
            position.x += 2f;
            GameObject bullet = Instantiate<GameObject>(this.abilities[2].GetPrefab(), position, this.transform.rotation);
            bullet.GetComponent<Bullet>().damage = this.abilities[2].CalculateMagnitude(this.currentAttack);
            this.currentMana -= this.abilities[2].GetManaCost();
            this.abilities[2].Cast();
        }
    }

    public override void CastAbility4()
    {
        if (this.abilities[3].isReady())
        {
            GameObject storm = Instantiate<GameObject>(this.abilities[3].GetPrefab());
            storm.GetComponent<ArcaneStorm>().SetAttack(this.abilities[3].CalculateMagnitude(this.currentAttack));
            this.currentMana -= this.abilities[3].GetManaCost();
            this.abilities[3].Cast();
        }
    }

    void FixedUpdate ()
    {
        for (int i = 0; i < this.abilities.Length; i++)
        {
            this.abilities[i].FixedUpdate();
        }
    }
}
