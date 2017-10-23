using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public float lifetime;
    public int damage;
    public Rigidbody2D rb2D;
    public Vector2 startVelocity;
    public GameObject endFX;

    public virtual void OnEnable ()
    {
        this.rb2D.WakeUp();
    }

    public virtual void OnDisable ()
    {
        this.rb2D.Sleep();
    }

    public virtual void OnTriggerEnter2D (Collider2D collidee)
    {
        Instantiate(endFX, this.transform.position, this.transform.rotation);
        if(collidee.tag.Equals("Player") || collidee.tag.Equals("Enemy"))
            collidee.GetComponent<Unit>().TakeDamage(this.damage);
    }
}
