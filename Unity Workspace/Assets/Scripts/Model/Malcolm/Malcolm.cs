using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malcolm : Hero {

    private Move basicAttack;

    void Awake()
    {
        this.maxHealth = 100;
        this.currentHealth = this.maxHealth;

        this.maxMana = 100;
        this.currentMana = this.maxMana;

        this.basicAttack = new Move(1f, "Javelin Throw");
    }

    public override void BasicAttack()
    {
        if (this.basicAttack.isReady())
        {
            Vector3 position = this.transform.position;
            position.x += 2f;
            GameObject bullet = basicAttackPooler.GetAvailable();
            bullet.transform.position = position;
            bullet.SetActive(true);
            this.basicAttack.Cast();
        }

    }

    void FixedUpdate()
    {
        basicAttack.FixedUpdate();
    }
}
