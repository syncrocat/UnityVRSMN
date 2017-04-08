using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : Interactable {
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
		if (targetObject.flipped == "flipping") {
			if (fracJourney >= 0.95f) {
				targetObject.transform.rotation = endRotation; // If we over-rotated
				targetObject.flipped = "flipped";
			} else {
				targetObject.transform.rotation = Quaternion.Lerp (startRotation, endRotation, distCovered);
			}
		} 
//		else if (mode == "unflipping") {
//			if (fracJourney >= 0.95f) {
//				targetObject.transform.rotation = endRotation; // If we over-rotated
//				mode = "unflipped";
//			} else {
//				targetObject.transform.rotation = Quaternion.Lerp (startRotation, endRotation, distCovered);
//			}
//		}
	}

	public override void onEnter () {

	}
	public override void onExit (){}
	public override void onClick (){
//		if (mode == "flipped") {
//			mode = "unflipping";
//			startRotation = targetObject.transform.rotation;
//			endRotation = Quaternion.Euler(startRotation.eulerAngles + new Vector3 (0, 180, 0));
//			startTime = Time.time;
//		} 
//		else 
		if (targetObject.flipped == "unflipped") {
			targetObject.flipped = "flipping";
			startRotation = targetObject.transform.rotation;
			endRotation = Quaternion.Euler(startRotation.eulerAngles + new Vector3 (0, 180, 0));
			startTime = Time.time;
		}
	}
}
