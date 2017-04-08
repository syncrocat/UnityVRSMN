using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Messages : Receiver {
	public textToSurface textField;
	Dictionary<string, List<string>> conversations;
	List<string> names;
	int conversationNumber;
	// Use this for initialization
	void Start () {
		conversations = new Dictionary<string, List<string>>();
		conversations ["Rick"] = new List<string> ();
		conversations ["Morty"] = new List<string> ();
		conversations ["Jerry"] = new List<string> ();
		conversations ["Summer"] = new List<string> ();
		names = new List<string> ();
		names.Add ("Rick");
		names.Add ("Morty");
		names.Add ("Jerry");
		names.Add ("Summer");
		conversationNumber = 0;

		conversations ["Rick"].Add ("***Messages With: Rick***");
		conversations ["Rick"].Add ("Lucas: Sup dude");
		conversations ["Rick"].Add ("You: nm Bro");

		conversations ["Morty"].Add ("***Messages With: Grant***");

		conversations ["Jerry"].Add ("***Messages With: Jerry***");
		conversations ["Jerry"].Add ("Jerry: Hey why you don't respond?");

		conversations ["Summer"].Add ("***Messages With: Summer***");
		conversations ["Summer"].Add ("You: hey ;)");


//		textField.updateText (conversations [names [0]] [0]);
		//textField.updateText("Testing");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextConversation() {
		Debug.Log ("Next Conversation requested");
		conversationNumber += 1;
		if (conversationNumber >= names.Count)
			conversationNumber = 0;
//		List<string> sample = new List<string> ();
//		sample.Add ("A");
//		sample.Add ("B");
		//string test = String.Join (" ", new List<string> ());
//		string[] test2 = sample.ToArray ();
		string[] temp = conversations[names[conversationNumber]].ToArray();
		string conversationString = string.Join("\n  ", temp);
		textField.updateText (conversationString);
	}

	public void prevConversation() {
		Debug.Log ("Previous Conversation requested");
		conversationNumber -= 1;
		if (conversationNumber < 0)
			conversationNumber = names.Count - 1;
		string conversationString = string.Join("\n  ", conversations[names[conversationNumber]].ToArray());
		textField.updateText (conversationString);
	}

	public override void speakerFunc(string str) {
		conversations [names [conversationNumber]].Add ("You: " + str);
		string conversationString = string.Join("\n  ", conversations[names[conversationNumber]].ToArray());
		textField.updateText (conversationString);
	}
}
