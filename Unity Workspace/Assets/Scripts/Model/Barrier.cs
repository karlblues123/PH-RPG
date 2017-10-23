using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public float lifetime;
    public bool reflective;
    
    public virtual void FixedUpdate ()
    {
        this.lifetime -= Time.fixedDeltaTime;
        if(this.lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void OnTriggerEnter2D (Collider2D collidee)
    {
        if(reflective)
        {
            collidee.GetComponent<Rigidbody2D>().velocity *= -1;
            if (this.gameObject.layer == LayerMask.NameToLayer("Player"))
                collidee.gameObject.layer = LayerMask.NameToLayer("Player");
            else
                collidee.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
