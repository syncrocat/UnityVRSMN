using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textToSurface : MonoBehaviour {
	public string text = "test";
	public float textScale = 1f;
	public GameObject threeDTextPREFAB;
	private GameObject TextObject;
	public int maxChars;
	public int maxRows;

	void Start () {
		updateText (text);
	}

	public void updateText(string text){
		Destroy(TextObject);
		Vector3 spawnLocation = new Vector3(0,0,0);
		TextObject = (GameObject)Instantiate(threeDTextPREFAB,spawnLocation,Quaternion.identity);
		TextMesh textPart = TextObject.GetComponent<TextMesh>();

		Transform beforePair = TextObject.transform;

		TextObject.transform.parent = transform;

		Vector3 topLeft = Vector3.zero;
		topLeft.Set ((float)-5,(float)0.01,(float)5);
		TextObject.transform.localPosition=topLeft;

		TextObject.transform.localRotation = Quaternion.identity;
		TextObject.transform.Rotate (90, 0, 0);


		string formattedText = "";
		int count = 0;
		int rows = 0;

		foreach(char c in text){
			formattedText += c;
			if (c == '\n') {
				count = 0;
				rows++;
			} else {
				count++;
				if (count >= (maxChars - 3) && rows >= maxRows) {
					formattedText += "...";
					break;
				}else if (count >= maxChars) {
					formattedText += "\n";
					count = 0;
					rows++;
				}
			}
		}

		textPart.text = formattedText;
		TextObject.transform.localScale = new Vector3(1,1,1);

		Vector3 scale = TextObject.transform.localScale;
		scale.y *= textScale; // your new value
		scale.x *= textScale; // your new value
		TextObject.transform.localScale = scale;

		//TextObject.transform.localScale *= textScale;
		//TextObject.transform.localScale=TextObject.transform.lossyScale;
		//Debug.Log (TextObject.transform.lossyScale + "" + text+""+TextObject.transform.localScale);


	}

}