using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class SurfaceChild {
	public GameObject 			entity;
	public Vector2 				placement;
	public bool 				instantiated;

	public SurfaceChild(GameObject entity, Vector2 placement) {
		this.entity = entity;
		this.placement = placement;
		this.instantiated = false;
	}
}*/

public class Surface {
	// Store children for updating
	private List<GameObject> 	children;

	// Position represents (0, 0) on the plane
	public Vector3				position;
	public Vector3 				normal;
	private GameObject parent;
	// GameObject representing the plane
	private GameObject 			plane;

	public Surface(GameObject parent, Vector3 position, Vector3 normal) {
		this.children = new List<GameObject>();

		this.position = position;
		this.normal = normal;
		this.plane = new GameObject ("plane");
		this.parent = parent;
		this.plane.transform.parent = this.parent.transform;
		this.plane.transform.position = this.parent.transform.position;
		this.plane.transform.rotation = this.parent.transform.rotation;
	}

	// Adds a child to the children list and return it's index
	public int addChild(GameObject gameObject, Vector2 placement) {
		// Add to end of list
		this.children.Add (gameObject);

		// Rotate and move the plane to match the x, y plane
		this.plane.transform.position = new Vector3      (0, 0, 0);
		this.plane.transform.LookAt                      (new Vector3(0, 0, 1));

		// Place the entity on the x, y plane based on it's placement
		gameObject.transform.position = new Vector3      (0, 0, 0);
		this.plane.transform.LookAt                      (new Vector3(0, 0, 1));
		gameObject.transform.position = new Vector3      (placement.x, placement.y, 0);

		// Assign it's parent as the plane transform
		gameObject.transform.parent = this.plane.transform;

		// Rotate the plane back to it's position
		this.plane.transform.position = this.parent.transform.position;
		this.plane.transform.rotation = this.parent.transform.rotation;

		// Return the index
		return this.children.Count;
	}

	// Returns a child to the specified index
	public GameObject getChild(int i) {
		return this.children [i];
	}
}
