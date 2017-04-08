using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSurface : MonoBehaviour {
	private Surface surface;
	public GameObject bookPage;
	// Use this for initialization
	void Start () {
		surface = new Surface (this.gameObject, transform.position, transform.rotation.eulerAngles);
		GameObject page = Instantiate (bookPage) as GameObject;
		page.transform.rotation = Quaternion.Euler (0, 0, 0);
		page.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		surface.addChild (page, new Vector2 (0, 0));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
