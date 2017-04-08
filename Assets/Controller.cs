using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * CONTROLLER
 * 
 */
public class Controller : MonoBehaviour {
	public GameObject camera;
	private GameObject currentHover;

	void Start () {
		currentHover = null;
	}

	//public delegate void ClickAction();
	//public static event ClickAction Clicked;

	void Update () {
		if (GvrViewer.Instance.Triggered) {
			//Clicked ();
		}

		RaycastHit hit;

		if (Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 100)) {
			GameObject target = hit.collider.gameObject;

			// If we've left the old object and entered a new object...
			if (target != currentHover) {
				// If we were in an old object broadcast it the exit message
				if (currentHover != null) {
					currentHover.BroadcastMessage ("onExit", SendMessageOptions.DontRequireReceiver);
				}
				// Broadcast the enter message to the new object
				target.BroadcastMessage ("onEnter", SendMessageOptions.DontRequireReceiver);
				currentHover = target;
			}

			if (GvrViewer.Instance.Triggered) {
				target.BroadcastMessage ("onClick", SendMessageOptions.DontRequireReceiver);
			}
		} else {
			// If we leave the object and don't enter a new object, broadcast the exit message
			if (currentHover != null) {
				currentHover.BroadcastMessage ("onExit", SendMessageOptions.DontRequireReceiver);
				currentHover = null;
			}
		}
	}
}
