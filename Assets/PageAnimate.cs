using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageAnimate : MonoBehaviour {
	private int mode;
	Vector3 startVector;
	Vector3 endVector;
	float startTime;
	// Use this for initialization
	void Start () {
		mode = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (mode == 1) {
			float progress = Time.time - startTime;
			if (Time.time - startTime > 1) {
				mode = 0;
			} else {
				transform.position = Vector3.Lerp (startVector, endVector, Time.time - startTime);
			}
		}
	}
	public void animateOut() {
		mode = 1;
		startVector = transform.position;
		endVector = startVector + new Vector3 (0.65f, 0, 0);
		startTime = Time.time;
	}

	public void animateIn() {
		mode = 1;
		startVector = transform.position;
		endVector = startVector + new Vector3 (0, 0, -0.65f);
		startTime = Time.time;
	}
}
