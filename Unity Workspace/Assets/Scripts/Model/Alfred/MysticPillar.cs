using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticPillar : MonoBehaviour {

    public int damage;
    [SerializeField]
    float duration;
	
	public void Raycast ()
    {
        Vector2 origin = this.transform.position;
        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, new Vector2(0.8f, 1), 0f, Vector2.up, 10f, LayerMask.GetMask("Enemy"));
        if(hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if(hits[i].collider.tag.Equals("Enemy"))
                    hits[i].collider.gameObject.GetComponent<Unit>().TakeDamage(this.damage);
            }
        }
    }
    
    // Update is called once per frame
	void FixedUpdate ()
    {
        this.duration -= Time.fixedDeltaTime;
        if (duration <= 0)
            Destroy(this.gameObject);
	}
}
