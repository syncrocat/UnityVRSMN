using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Facebook.MiniJSON;


public class FBscript : MonoBehaviour {

	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;


	//initilize facebook
	void Awake () {
		FB.Init (SetInit, OnHideUnity);
	}

	//check if logged in
	void SetInit(){

		if(FB.IsLoggedIn){
			Debug.Log("FB is logged in");
		} else {
			Debug.Log("FB is not logged in");
		}

		DealWithFBMenus (FB.IsLoggedIn);

	}

	//pause game if unity is hidden
	void OnHideUnity(bool isGameShown){
	
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	//
	public void FBlogin(){
		//creat a list to hold permissions
		/*List <string> permissions = new List <string> ();
		//ask for permissions
		permissions.Add("public_profile");
		permissions.Add("user_photos");*/

		//Log in with read permisions
		FB.LogInWithReadPermissions (
			new List<string>(){"public_profile", "email", "user_friends"}
		, AuthcallBack);
	}

	//error handeling if login fails
	void AuthcallBack(IResult result){
	
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");

				SceneManager.LoadScene ("Exhibit");
			} else {
				Debug.Log ("FB is not logged in");
			}

			//call corisponding method
			DealWithFBMenus (FB.IsLoggedIn);
		}
	}

	//Controlls the showing/hiding of Logged in menu and loged out menu
	void DealWithFBMenus(bool isLoggedIn){
		//swap what menu is avalable
		if (isLoggedIn) {
			DialogLoggedIn.SetActive (true);
			DialogLoggedOut.SetActive (false);


			//grab firstname
			FB.API("/me?fields=first_name",HttpMethod.GET,DisplayUsername);
			//grab profile picture
			FB.API("/me/picture?type=square&height=128&width=128",HttpMethod.GET,DisplayProfilePic);



			//Print the acess token and all permisions
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}



		} 
		else {
			DialogLoggedIn.SetActive (false);
			DialogLoggedOut.SetActive (true);
		}

	}

	//display username with message
	void DisplayUsername(IResult result){
	
		//grab the text component of the name
		Text UserName = DialogUsername.GetComponent<Text> ();

		//error check
		if (result.Error == null) {
			//show the username with message
			UserName.text = "Hi there, " + result.ResultDictionary ["first_name"];
		} else {
			Debug.Log (result.Error);
		}
	}

	//diplay profile picture
	void DisplayProfilePic(IGraphResult result){
		//error check
		/*if (result.Texture != null) {
			//grab the profile pic image
			Image ProfilePic = DialogProfilePic.GetComponent<Image> (); 
			//cast the image into a sprite to display
			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());

		} else {
			Debug.Log (result.Error);
		}*/

	}


	///URL generation below
	//http://graph.facebook.com/10212469023309252/picture?type=large

//	 URLGenerator(){
//
//		var dict = Json.Deserialize(jsonString) as Dictionary<string,object>;
//		string userName = dict["name"];
//
//	
//	}
}

//https://graph.facebook.com/{ID_ALBUM}?fields=photos&access_token={}

