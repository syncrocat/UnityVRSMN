using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePuller : Interactable {
	public GameObject page;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void onEnter (){}
	public override void onExit (){}
	public override void onClick (){
		page.transform.position = transform.position + new Vector3 (0, 0, 0.85f);
	}
}
