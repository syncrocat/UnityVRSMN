using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChild : Interactable {
	public Interactable parent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void onEnter () {
		parent.onEnter ();
	}

	public override void onExit () {
		parent.onExit ();
	}

	public override void onClick () {
		parent.onClick ();
	}
}
