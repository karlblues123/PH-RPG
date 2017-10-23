using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int maxHealth, maxAttack, maxDefense, currentHealth, currentAttack, currentDefense;
    public GameProperUI ui;

    public virtual void Start ()
    {
        ui = GameObject.Find("Hero UI").GetComponent<GameProperUI>();
    }

    public void TakeDamage (int incomingDmg)
    {
        int finalDamage = incomingDmg / currentDefense;
        if (finalDamage <= 0)
            finalDamage = 1;
        this.currentHealth -= finalDamage;
        ui.DisplayDamagePopup(finalDamage, Camera.main.WorldToScreenPoint(this.transform.position));
    }
}
