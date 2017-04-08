using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpeak : Receiver {
	public textToSurface textOnSurface;
	public mapController map;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void speakerFunc(string str) {
		textOnSurface.updateText(str);
		map.searchUsers (str);
	}
}
