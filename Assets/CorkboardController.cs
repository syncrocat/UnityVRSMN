using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorkboardController : MonoBehaviour {

	public textToSurface theMessage1;
	public textToSurface theMessage2;
	public textToSurface theMessage3;
	public textToSurface yourMessage;
	private textToSurface[] messageDisplays;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateMessages(List<string[]> messages){
		messageDisplays = new textToSurface[]{ theMessage1, theMessage2, theMessage3 };
		yourMessage.updateText ("Make a post +");
		int index = 0;
		for(index = 0; index < 3; index++){
			if (index >= messages.Count - 1)
				break;
			string mess = messages[index][0];
			string user = messages[index][1];
			messageDisplays[index].updateText (mess+"\n-"+user);
		}
	}
}
