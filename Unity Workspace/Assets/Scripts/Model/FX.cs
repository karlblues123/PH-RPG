using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour {

    [SerializeField]
    ParticleSystem ps;
	
	void FixedUpdate ()
    {
       if(ps.isStopped)
        {
            Destroy(this.gameObject);
        }
	}
}
