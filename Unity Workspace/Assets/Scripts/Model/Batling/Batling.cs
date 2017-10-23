using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batling : Enemy {

    [SerializeField]
    ObjectPooler pooler;
    [SerializeField]
    Animator anim;
    private float flightTime;

    public override void Start ()
    {
        base.Start();
        this.flightTime = 0f;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
        this.currentAttack = this.maxAttack;
        this.currentDefense = this.maxDefense;
        this.currentHealth = this.maxHealth;
    }

    public override void BasicAttack()
    {
        Vector2 position = this.transform.position;
        position.x -= 2f;
        GameObject bullet = pooler.GetAvailable();
        bullet.GetComponent<Bullet>().damage = this.currentAttack;
        bullet.transform.position = position;
        bullet.SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
        this.flightTime += Time.deltaTime;
        if(this.flightTime >= 5f)
        {
            anim.SetBool("isAtk", true);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
	}
}
