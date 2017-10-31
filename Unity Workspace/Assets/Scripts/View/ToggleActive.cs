using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour {

	[Tooltip("The desired GameObject to toggle between inactive or active in scene.")]
	public GameObject TargetObject;
	
	public void Toggle () {
		TargetObject.active = !TargetObject.active;
	}
}
