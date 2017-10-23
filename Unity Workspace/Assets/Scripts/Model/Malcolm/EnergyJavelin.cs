using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyJavelin : Bullet {

    [SerializeField]
    TrailRenderer trailFX;
	
    // Use this for initialization
	void Start ()
    {
        this.lifetime = 3f;
        this.rb2D.velocity = this.startVelocity;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        this.rb2D.velocity = this.startVelocity;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        trailFX.Clear();
    }

    void FixedUpdate ()
    {
        this.lifetime -= Time.fixedDeltaTime;
        if (this.lifetime <= 0)
        {
            this.lifetime = 3f;
            this.gameObject.SetActive(false);
        }
    }
}
