using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : Interactable {
	public Bringable target;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void onEnter () {
	}

	public override void onExit () {
	}

	public override void onClick () {
		target.bringFar ();
	}
}
