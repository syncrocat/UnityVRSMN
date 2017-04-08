using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class LoadMuseum : MonoBehaviour {

	/////// everything below is to load new scene

	public Rect button = new Rect (0, 0, 200, 110);
	public string buttonlabel = "Load Museum";
	public string levelToload ="Exhibit";

	private void OnGUI(){

		if (GUI.Button (button, buttonlabel)){
			//load the scene on button click
			SceneManager.LoadScene(levelToload);
		}
	}
}
