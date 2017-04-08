using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urlToSurface : MonoBehaviour {
	public string url = "https://graph.facebook.com/838109535/picture?type=large";
	WWW www;
	bool done = false;
	// Use this for initialization
	void Start () {
		www = new WWW(url);
	}
	
	// Update is called once per frame
	void Update () {
		if (www.isDone && !done) {
			drawImage ();
			done = true;
		}
	}
	public void updateImage(string url){
		this.url = url;
		www = new WWW(url);
		done = false;
	}
	public void drawImage(){
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = www.texture;
	}
	//

}