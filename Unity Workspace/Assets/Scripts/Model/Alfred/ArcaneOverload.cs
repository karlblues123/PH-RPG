using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneOverload : Bullet {
    
    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = this.startVelocity;
    }

    void FixedUpdate()
    {
        this.lifetime -= Time.fixedDeltaTime;
        if (this.lifetime < 0)
        {
            int layer = LayerMask.GetMask("Enemy");
            if(this.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy Bullet")))
            {
                layer = LayerMask.GetMask("Player");
            }
            Destroy(this.gameObject);
            Instantiate<GameObject>(endFX, this.transform.position, this.transform.rotation);
            
            RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, 2.5f, Vector2.right, 0f, layer);
            if (hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.tag.Equals("Player") || hits[i].collider.tag.Equals("Enemy"))
                        hits[i].collider.gameObject.GetComponent<Unit>().TakeDamage(this.damage * 15);
                }
            }
        }

    }

    public override void OnTriggerEnter2D(Collider2D collidee) {}

    public void OnTriggerStay2D(Collider2D collidee)
    {
        if (collidee.tag.Equals("Player") || collidee.tag.Equals("Enemy"))
            collidee.gameObject.GetComponent<Unit>().TakeDamage(this.damage);
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        this.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Collider2D>().enabled = true;
    }
}
