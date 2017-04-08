using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messager : Interactable {
	public string messageToSend;
	public Messager recipient;
	private List<string> receivedMessages;
	// Use this for initialization
	void Start () {
		receivedMessages = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void receiveMessage(string message) {
		receivedMessages.Add (message);
	}

	public override void onEnter () {
		Debug.Log ("This object's received messages:");
		foreach (string message in receivedMessages) {
			Debug.Log (message);
		}
	}
	public override void onExit () {}
	public override void onClick () {
		recipient.receiveMessage (messageToSend);
		Debug.Log ("Sent message: " + messageToSend);
	}
}
