using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextConversationButton : Interactable {
	public Messages messageBoard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void onEnter (){}
	public override void onExit (){}
	public override void onClick (){
		messageBoard.nextConversation ();
	}
}
