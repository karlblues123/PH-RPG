using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperUI : MonoBehaviour {

    public GameObject healthBar, manaBar, heroPortrait, damagePopupPrefab;
    public GameObject[] abilityIcons;
    public Hero heroModel;
    
    // Use this for initialization
	void Start ()
    {
        heroModel = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        
        //Health Slider
        UnityEngine.UI.Slider healthSliderComponent = healthBar.GetComponent<UnityEngine.UI.Slider>();
        healthSliderComponent.maxValue = heroModel.maxHealth;
        healthSliderComponent.value = heroModel.currentHealth;

        //Mana Slider
        UnityEngine.UI.Slider manaSliderComponent = manaBar.GetComponent<UnityEngine.UI.Slider>();
        manaSliderComponent.maxValue = heroModel.maxMana;
        manaSliderComponent.value = heroModel.currentMana;

        //Text
        healthBar.GetComponentInChildren<UnityEngine.UI.Text>().text = heroModel.currentHealth + " / " + heroModel.maxHealth;
        manaBar.GetComponentInChildren<UnityEngine.UI.Text>().text = heroModel.currentMana + " / " + heroModel.maxMana;

        //Cooldown
        for (int i = 0; i < abilityIcons.Length; i++)
        {
            abilityIcons[i].GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.GetComponent<UnityEngine.UI.Slider>().value = heroModel.currentHealth;
        manaBar.GetComponent<UnityEngine.UI.Slider>().value = heroModel.currentMana;

        healthBar.GetComponentInChildren<UnityEngine.UI.Text>().text = heroModel.currentHealth + " / " + heroModel.maxHealth;
        manaBar.GetComponentInChildren<UnityEngine.UI.Text>().text = heroModel.currentMana + " / " + heroModel.maxMana;

        int cooldown;
        for (int i = 0; i < abilityIcons.Length; i++)
        {
            cooldown = Mathf.RoundToInt(heroModel.abilities[i].GetCurrentCooldown());
            if (cooldown > 0)
                abilityIcons[i].GetComponentInChildren<UnityEngine.UI.Text>().text = cooldown.ToString();
            else
                abilityIcons[i].GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        }
    }

    //Display damage popup
    public void DisplayDamagePopup (int damage, Vector2 location)
    {
        GameObject popup = Instantiate<GameObject>(damagePopupPrefab, this.transform);
        popup.GetComponent<UnityEngine.UI.Text>().text = damage.ToString();
        popup.transform.position = location;
        Destroy(popup, 1f);
    }
}
