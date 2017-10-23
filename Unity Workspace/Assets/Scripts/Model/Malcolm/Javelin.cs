using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javelin : Bullet {

    [SerializeField]
    Vector2 acceleration;
    
    // Use this for initialization
	void Start ()
    {
        this.lifetime = 3f;
        this.rb2D.velocity = this.startVelocity;
    }

    public override void OnEnable ()
    {
        base.OnEnable();
        this.rb2D.velocity = this.startVelocity;
        float angle = Mathf.Atan2(this.rb2D.velocity.y, this.rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate ()
    {
        this.lifetime -= Time.fixedDeltaTime;
        this.rb2D.velocity += this.acceleration;
        float angle = Mathf.Atan2(this.rb2D.velocity.y, this.rb2D.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (this.lifetime <= 0)
        {
            this.lifetime = 3f;
            this.gameObject.SetActive(false);
        }
    }
}
