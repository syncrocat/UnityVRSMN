using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : Interactable {
	public GameObject destinationRoom;
	public GameObject camera;
	public GameObject fadeSphere;
	public GameObject map;
	public textToSurface lobbyButtonText;
	public bool isGoingToLobby;
	private bool fading;
	private float startTime;
	// Use this for initialization
	void Start () {
		fading = false;
		fadeSphere.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			if (Time.time - startTime > 0.2) {
				camera.transform.position = destinationRoom.transform.position;
				//map.transform.position = destinationRoom.transform.position;
				fadeSphere.transform.position = camera.transform.position;
				fadeSphere.GetComponent<Renderer> ().enabled = false;
				fading = false;
				if (isGoingToLobby) {
					lobbyButtonText.updateText("");
				} else {
					lobbyButtonText.updateText("Lobby");
				}
			}
		}
	}

	public override void onEnter() {
		
	}

	public override void onExit() {

	}

	public override void onClick() {
		fading = true;
		startTime = Time.time;
		fadeSphere.GetComponent<Renderer> ().enabled = true;
	}
}
