using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringable : MonoBehaviour {
	static int numClose = 0;
	public GameObject camera;
	public PageAnimate animated;
	Vector3 startPosition;
	Vector3 endPosition;
	string mode;
	float startTime;
	float endTime;
	float speed;
	float spinSpeed;
	float journeyLength;
	Vector3 farPosition; // Where the object should be on the wall
	Vector3 closePosition; // Where the object should be when brought to the camera
	//Quaternion endRotation; // Where the object should rotate to when viewing the back

	Quaternion startRotation;
	Quaternion endRotation;
	Quaternion closeRotation;
	Quaternion farRotation;

	public Vector3 closeRotationVector;
	public Vector3 closePositionVector;
//	public GameObject[] farObjects;
//	public GameObject[] closeObjects;

	void Start() {
		mode = "far";
		speed = 4.0f;
		spinSpeed = 0.5f;
		closePosition = camera.transform.position + closePositionVector;
		closeRotation = Quaternion.Euler (closeRotationVector);
		farPosition = transform.position;
		farRotation = transform.rotation;

//		foreach (GameObject obj in farObjects) {
//			Renderer r = obj.GetComponent<Renderer> ();
//			r.enabled = true;
//		}
//		foreach (GameObject obj in closeObjects) {
//			Renderer r = obj.GetComponent<Renderer> ();
//			r.enabled = false;
//		}
	}

	void Update() {
		
		float distCovered;
		float fracJourney;
		if (mode == "coming") {
			distCovered = (Time.time - startTime) * speed;
			journeyLength = Vector3.Distance (startPosition, endPosition);
			fracJourney = distCovered / journeyLength;
			// Check if we have reached our destination yet
			if (fracJourney >= 1) {
				transform.position = endPosition; // In case we overshot
				transform.rotation = endRotation;
				mode = "close";
				if (!(animated == null))
					animated.animateOut ();
			} else {
				transform.position = Vector3.Lerp (startPosition, endPosition, fracJourney);
				transform.rotation = Quaternion.Lerp (startRotation, endRotation, fracJourney);
			}
		} else if (mode == "going") {
			distCovered = (Time.time - startTime) * speed;
			fracJourney = distCovered / journeyLength;
			// Check if we have reached our destination yet
			if (fracJourney >= 1) {
				transform.position = endPosition; // In case we overshot
				transform.rotation = endRotation;
				mode = "far";
				numClose -= 1;
				if (!(animated == null))
					animated.animateIn ();
			} else {
				transform.position = Vector3.Lerp (startPosition, endPosition, fracJourney);
				transform.rotation = Quaternion.Lerp (startRotation, endRotation, fracJourney);
			}
		} 
//		else if (mode == "flipping") {
//			journeyLength = 0.5f;
//			distCovered = (Time.time - startTime) * spinSpeed;
//			fracJourney = distCovered / journeyLength;
//			if (fracJourney >= 0.95f) {
//				transform.rotation = endRotation; // If we over-rotated
//				mode = "flipped";
//			} else {
//				transform.rotation = Quaternion.Lerp (transform.rotation, endRotation, distCovered);
//			}
//		} else if (mode == "unflipping") {
//			journeyLength = 0.5f;
//			distCovered = (Time.time - startTime) * spinSpeed;
//			fracJourney = distCovered / journeyLength;
//			if (fracJourney >= 0.95f) {
//				transform.rotation = endRotation; // If we over-rotated
//				mode = "close";
//			} else {
//				transform.rotation = Quaternion.Lerp (transform.rotation, endRotation, distCovered);
//			}
//		}
	}

	public void bringClose () {
		Debug.Log ("Bring Close");
		if (mode == "far" && numClose == 0) {
			numClose += 1;
			mode = "coming";
			startTime = Time.time;
			startPosition = farPosition;
			startRotation = farRotation;
			endPosition = closePosition;
			endRotation = closeRotation;
		} 
//			else if (mode == "close") {
//			mode = "flipping";
//			endRotation = transform.rotation * Quaternion.AngleAxis (180, new Vector3 (0, 1, 0));
//			startTime = Time.time;
//		} else if (mode == "flipped") {
//			mode = "unflipping";
//			endRotation = transform.rotation * Quaternion.AngleAxis (-180, new Vector3 (0, 1, 0));
//			startTime = Time.time;
//		}
	}

	public void bringFar() {
		Debug.Log ("BringFar");
		if (mode == "close") {
			mode = "going";
			startTime = Time.time;
			startPosition = closePosition;
			startRotation = closeRotation;
			endPosition = farPosition;
			endRotation = farRotation;
		}
	}
}
