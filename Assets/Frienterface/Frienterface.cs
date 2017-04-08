using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class Frienterface : MonoBehaviour {
	public delegate void TextureHandler (Texture texture, string name, string id);

	public static bool GetFriends(TextureHandler handler) {
		if (FB.IsLoggedIn) {
			FB.API("/me/friends", HttpMethod.GET, (IGraphResult result) => {
				string raw = result.RawResult;

				int s = raw.IndexOf("{\"data\":[") + 9;
				int f = raw.IndexOf("],");

				string[] list = raw.Substring(s, f - s).Split(',');

				for (int i = 0; i < list.Length; i += 2) {
					// Keys
					string k_name 	= "{\"name\":\"";
					string k_id		= "\",\"id\":\"";
					string k_end 	= "\"}";

					// Values
					string name 	= list[i]		.Substring(9, list[i].Length 		- 9 - 1);
					string id 		= list[i + 1]	.Substring(6, list[i + 1].Length 	- 6 - 2);

					FB.API("/" + id + "/picture?type=square&height=128&width=128", HttpMethod.GET, (IGraphResult pic) => {
						Debug.Log("Is Null?!?" + (pic.Texture == null));

						handler(

							pic.Texture

						, name, id);
					});
				}
			});

			return true;
		} 
		else {
			return false;
		}
	}

	// Pause game if unity is hidden
	void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			Time.timeScale = 0;
		} 
		else {
			Time.timeScale = 1;
		}
	}
}
