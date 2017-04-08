using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour {
	public mapController map;
	public DataModel dm;
	// Use this for initialization
	void Start () {
		dm.buildLists ();
		Debug.Log ("dm.friends"+dm.friends);
		Debug.Log ("dm.count"+dm.friends.Count);
		Debug.Log ("dm.friends"+dm.friends[0]);
		map.updateUsersList (dm.friends);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
