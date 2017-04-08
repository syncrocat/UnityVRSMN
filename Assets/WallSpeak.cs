using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpeak : Receiver {
	public textToSurface textOnSurface;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void speakerFunc(string str) {

		textOnSurface.updateText(str);
	}
}
