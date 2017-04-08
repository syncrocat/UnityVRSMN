using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToUser : Interactable {
	public Person currentUser;
	public mapController map;
	public int buttonOffset;
	public DataModel dm;

	public CorkboardController corkboard;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void onEnter (){
	
	}

	public override void onExit (){
	
	}

	public override void onClick (){
		Debug.Log ("I WAS CLICKED!!!");
		Debug.Log (map.users.Count);
		Debug.Log (map.currentIndex);
		Debug.Log (buttonOffset);
		if(map.users.Count > map.currentIndex + buttonOffset){
			dm.updateViews ();
			Debug.Log ("hehe!!!");
			currentUser = map.users [map.currentIndex + buttonOffset];
			Debug.Log ("currentUser:"+currentUser.wall);
			corkboard.updateMessages (currentUser.wall);
			//update all the other parts of the room
		}
	}
}
