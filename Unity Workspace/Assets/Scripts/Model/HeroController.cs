using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    [SerializeField] Hero modelHero;
    [SerializeField]
    Animator anim;
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
        InputHandler();	
	}

    void Movement ()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    void InputHandler ()
    {
        if(Input.GetMouseButton(0))
        {
            anim.SetTrigger("Basic_Attack");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && modelHero.abilities[0].GetManaCost() <= modelHero.currentMana)
        {
            anim.SetTrigger("Spell_Cast_1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && modelHero.abilities[1].GetManaCost() <= modelHero.currentMana)
        {
            anim.SetTrigger("Spell_Cast_2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && modelHero.abilities[2].GetManaCost() <= modelHero.currentMana)
        {
            anim.SetTrigger("Spell_Cast_3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && modelHero.abilities[3].GetManaCost() <= modelHero.currentMana)
        {
            anim.SetTrigger("Spell_Cast_4");
        }
    }
}
