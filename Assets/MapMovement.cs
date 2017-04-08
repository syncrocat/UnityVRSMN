using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMovement : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	public float currentY = 0;

	// Update is called once per frame
	void Update () {
		float xRotationAngle = Camera.main.transform.eulerAngles.x;
		if(xRotationAngle < 25 || xRotationAngle >= 90){
			currentY = Camera.main.transform.eulerAngles.y;
		}
		transform.rotation =  Quaternion.AngleAxis(currentY, Vector3.up);
		Quaternion originalRot = transform.rotation;
		if (xRotationAngle < 10 || xRotationAngle >= 90) {
			xRotationAngle = 0;
		} else {
			xRotationAngle -= 10;
			if (xRotationAngle > 25 && xRotationAngle < 90) {
				xRotationAngle = 25;
			}
		}
		transform.rotation = originalRot * Quaternion.AngleAxis(xRotationAngle, Vector3.left);
	}
}
