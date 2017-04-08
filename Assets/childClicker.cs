using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childClicker : Interactable {
	public bool hasBeenClicked = false;
	public override void onEnter() {

	}

	public override void onExit() {

	}
	public override void onClick () {
		hasBeenClicked = true;
	}
}
