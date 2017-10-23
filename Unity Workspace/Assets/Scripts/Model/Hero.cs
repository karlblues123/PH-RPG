using UnityEngine;

public class Hero : Unit {

    public string heroName;
    public int maxMana, maxCritChance, maxCritDmg, currentMana, currentCritChance, currentCritDmg, 
        maxPower, currentPower, maxToughness, currentToughness, maxVitality, currentVitality, 
        maxWisdom, currentWisdom, maxDexterity, currentDexterity, maxFerocity, currentFerocity;
    public ObjectPooler basicAttackPooler;
    public Ability[] abilities;
 
    public virtual void Awake ()
    {
        CalculateAttack();
        CalculateDefense();
        CalculateHealth();
        CalculateMana();
        CalculateCriticalChance();
        CalculateCriticalDamage();
    }

	public override void Start ()
    {
        base.Start();
    }

    public virtual void BasicAttack ()
    {

    }

    public virtual void CastAbility1 ()
    {

    }

    public virtual void CastAbility2 ()
    {

    }

    public virtual void CastAbility3 ()
    {

    }

    public virtual void CastAbility4 ()
    {

    }

    public void CalculateHealth ()
    {
        this.maxHealth = 100 + (this.currentVitality * 10);
        this.currentHealth = this.maxHealth;
    }

    public void CalculateMana ()
    {
        this.maxMana = 100 + (this.currentWisdom * 10);
        this.currentMana = this.maxMana;
    }

    public void CalculateAttack ()
    {
        this.maxAttack = Mathf.RoundToInt(this.currentPower * 1.5f);
        this.currentAttack = this.maxAttack;
    }

    public void CalculateDefense ()
    {
        this.maxDefense = Mathf.RoundToInt(this.currentToughness * 1.2f);
        this.currentDefense = this.maxDefense;
    }

    public void CalculateCriticalChance ()
    {
        this.maxCritChance = Mathf.RoundToInt(this.currentDexterity * 0.5f);
        this.currentCritChance = this.maxCritChance;
    }

    public void CalculateCriticalDamage ()
    {
        this.maxCritDmg = 50 + Mathf.RoundToInt(this.currentFerocity * 0.5f);
        this.currentCritDmg = this.maxCritDmg;
    }
}
