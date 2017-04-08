using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapController : MonoBehaviour {
	public GameObject tlBut;
	public GameObject tmBut;
	public GameObject trBut;
	public GameObject blBut;
	public GameObject bmBut;
	public GameObject brBut;
	public GameObject alBut;
	public GameObject arBut;

	public GameObject[] allButtons;

	public GameObject voiceBut;
	public GameObject lobbyBut;
	// Use this for initialization

//	Speaker voiceButton;
	childClicker lobbyButClick;

	bool voiceIsDone = true;

	public List<Person> allUsers = new List<Person>();

	public List<Person> users = new List<Person>();
	public int currentIndex = 0;

	void Start () {
		allButtons = new GameObject[]{ tlBut, tmBut, trBut, blBut, bmBut, brBut };
	}

	public void searchUsers(string searchName){
		if (allUsers.Count < 4) {
			allButtons = new GameObject[]{ tlBut, tmBut, trBut, blBut, bmBut, brBut };
		}
		List<Person> newUsers = new List<Person> ();
		foreach (Person user in allUsers) {
			if (user.name.Contains (searchName)) {
				newUsers.Add (user);
			}
		}
		updateUsersList (newUsers);
	}

	public void updateUsersList(List<Person> users){
		if (allUsers.Count < 4) {
			allButtons = new GameObject[]{ tlBut, tmBut, trBut, blBut, bmBut, brBut };
		}
		this.users = users;
		updateUserButtons ();
	}

	public void updateUserButtons(){
		int index = 0;
		for (index = 0; index < 6; index++) {
			int listIndex = currentIndex + index;
			if (users.Count <= listIndex) {
				break;
			}
			Renderer renderer = allButtons [index].GetComponent<Renderer> ();
			renderer.material.mainTexture = users[listIndex].profPic;
		}
	}

	public void shiftLeft(){
		if (currentIndex != 0) {
			currentIndex -= 6;
			updateUserButtons ();
		}
	}

	public void shiftRight(){
		if (users.Count < currentIndex + 6) {
			currentIndex += 6;
			updateUserButtons ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

}
