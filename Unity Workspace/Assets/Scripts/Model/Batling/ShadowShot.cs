using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShot : Bullet {

    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = this.startVelocity;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        this.gameObject.GetComponent<Rigidbody2D>().velocity = this.startVelocity;
    }

    void FixedUpdate()
    {
        this.lifetime -= Time.fixedDeltaTime;
        if (this.lifetime < 0)
        {
            this.gameObject.SetActive(false);
            this.lifetime = 3f;
        }

    }

    public override void OnDisable()
    {
        base.OnDisable();
        this.gameObject.layer = LayerMask.NameToLayer("Enemy Bullet");
    }

    public override void OnTriggerEnter2D(Collider2D collidee)
    {
        base.OnTriggerEnter2D(collidee);
        if (!collidee.tag.Equals("Barrier"))
        {
            this.gameObject.SetActive(false);
            this.lifetime = 3f;
        }
    }
}
