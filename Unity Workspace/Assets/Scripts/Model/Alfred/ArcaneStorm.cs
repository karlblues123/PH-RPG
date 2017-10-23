using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneStorm : MonoBehaviour {

    [SerializeField]
    float lifetime;
    [SerializeField]
    float interval;
    private float currentInterval;
    [SerializeField]
    ObjectPooler pooler;
    [SerializeField]
    int attack, critChance, critDmg;

    void Start()
    {
        this.currentInterval = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (this.currentInterval >= interval)
        {
            Vector2 postion = new Vector2(Random.Range(-8.5f, 8.5f), 7);
            GameObject bullet = pooler.GetAvailable();
            bullet.GetComponent<Bullet>().damage = attack;
            bullet.transform.position = postion;
            bullet.SetActive(true);
            this.currentInterval = 0;
        }
        else
            this.currentInterval += Time.fixedDeltaTime;
        this.lifetime -= Time.fixedDeltaTime;
        if (this.lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
            
	}

    public int GetAttack ()
    {
        return this.attack;
    }

    public void SetAttack (int atk)
    {
        this.attack = atk;
    }

    public int GetCriticalChance ()
    {
        return this.critChance;
    }

    public void SetCriticalChance (int critChance)
    {
        this.critChance = critChance;
    }

    public int GetCriticalDamage ()
    {
        return this.critDmg;
    }

    public void SetCriticalDamage (int critDmg)
    {
        this.critDmg = critDmg;
    }
}
