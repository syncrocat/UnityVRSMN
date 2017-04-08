using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {
	abstract public void onEnter ();
	abstract public void onExit ();
	abstract public void onClick ();
}
