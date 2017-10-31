using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OverworldControls : MonoBehaviour {

	[Tooltip("Character's agent in the scene to move around.")]
	public NavMeshAgent characterAgent;
	
	// Update is called once per frame
	void Update () {
		InputReceiver();
	}

	void InputReceiver () {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			if(Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began) {
					RaycastPosition(Input.GetTouch(0).position);
				}
			}
		}
		if(Application.platform == RuntimePlatform.WindowsEditor) {
			if(Input.GetMouseButtonDown(0)) {
				RaycastPosition(Input.mousePosition);
			}
		}
	}

	void RaycastPosition (Vector3 pos) {
		RaycastHit hit;
        Debug.Log(pos);        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit, 200)) {
			characterAgent.destination = hit.point;
        }
	}
}
