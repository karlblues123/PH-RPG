using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour {

    [SerializeField] UnityEngine.UI.Text textComponent;
	
	void Start ()
    {
        textComponent.CrossFadeAlpha(0f, 1f, false);
    }
    
    // Update is called once per frame
	void Update ()
    {
        Vector2 position = this.transform.position;
        position.y += 0.5f;
        this.transform.position = position;
	}
}
