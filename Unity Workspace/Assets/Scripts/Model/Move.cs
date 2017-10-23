using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

    protected float maxCooldown, currentCooldown;
    protected string name;
    
    public Move (float cooldown, string name)
    {
        this.maxCooldown = cooldown;
        this.currentCooldown = 0;
        this.name = name;
    }

    public float GetMaxCooldown ()
    {
        return maxCooldown;
    }

    public void SetMaxCooldown (float maxCooldown)
    {
        this.maxCooldown = maxCooldown;
    }

    public float GetCurrentCooldown ()
    {
        return currentCooldown;
    }

    public void SetCurrentCooldown (float currentCooldown)
    {
        this.currentCooldown = currentCooldown;
    }

    public string GetName ()
    {
        return this.name;
    }

    public void SetName (string name)
    {
        this.name = name;
    }

    public void FixedUpdate ()
    {
        if(this.currentCooldown > 0)
            this.currentCooldown -= Time.fixedDeltaTime;
    }

    public bool isReady ()
    {
        if (this.currentCooldown <= 0f)
            return true;
        return false;
    }

    public virtual void Cast ()
    {
        this.currentCooldown = this.maxCooldown;
    }
}
