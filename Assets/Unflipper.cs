using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unflipper : Interactable {
	public Flippable targetObject;
	Quaternion startRotation;
	Quaternion endRotation;
	float startTime;
	float speed;
	// Use this for initialization
	void Start () {
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float journeyLength = 1.0f;
		float fracJourney = distCovered / journeyLength;
//		if (mode == "flipping") {
//			if (fracJourney >= 0.95f) {
//				targetObject.transform.rotation = endRotation; // If we over-rotated
//				mode = "flipped";
//			} else {
//				targetObject.transform.rotation = Quaternion.Lerp (startRotation, endRotation, distCovered);
//			}
//		} 
		if (targetObject.flipped == "unflipping") {
			if (fracJourney >= 0.95f) {
				targetObject.transform.rotation = endRotation; // If we over-rotated
				targetObject.flipped = "unflipped";
			} else {
				targetObject.transform.rotation = Quaternion.Lerp (startRotation, endRotation, distCovered);
			}
		}
	}

	public override void onEnter () {

	}
	public override void onExit (){}
	public override void onClick (){
		if (targetObject.flipped == "flipped") {
			targetObject.flipped = "unflipping";
			startRotation = targetObject.transform.rotation;
			endRotation = Quaternion.Euler(startRotation.eulerAngles + new Vector3 (0, 180, 0));
			startTime = Time.time;
		} 
//		else 
//		if (mode == "unflipped") {
//			mode = "flipping";
//			startRotation = targetObject.transform.rotation;
//			endRotation = Quaternion.Euler(startRotation.eulerAngles + new Vector3 (0, -180, 0));
//			startTime = Time.time;
//		}
	}
}
