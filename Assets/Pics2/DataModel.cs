using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModel : MonoBehaviour
{
	public List<Person> friends;
	public List<Post> posts;

	public Texture rick;
	public Texture rick_0;
	public Texture rick_1;
	public Texture rick_2;
	public Texture rick_3;
	public Texture morty;
	public Texture morty_0;
	public Texture morty_1;
	public Texture morty_2;
	public Texture morty_3;
	public Texture jerry;
	public Texture jerry_0;
	public Texture jerry_1;
	public Texture jerry_2;
	public Texture jerry_3;
	public Texture summer;
	public Texture summer_0;
	public Texture summer_1;
	public Texture summer_2;
	public Texture summer_3;

	public List<GameObject> frames;

	private string[][] comments= new string[][]{new string[]{"Bart","Eat my shorts"},new string[]{"Homer","FIRST!"},new string[]{"Lisa","What a beautiful pic!"},new string[]{"Marge","Walmart Customer Support"}};
	public void buildLists(){
		this.friends = new List<Person>();
		this.posts = new List<Post> ();

		Person p0=new Person("Rick",rick);
		p0.addPost("Saving Earth","Get Schwifty!",rick_0,comments);
		p0.addWallPost (new string[]{ "hungry for apples?", "Jerry" });
		p0.addWallPost (new string[]{ "because I am", "Jerry" });
		p0.addWallPost (new string[]{ "why does no one love me", "Jerry" });
		p0.addPost("Mug Shot","Got myself arrested...",rick_1,comments);
		p0.addPost("WUBALUBADUBDUB","I say it all the time guys",rick_2,comments);
		p0.addPost("Memories","RIP in peace Bird Person. I miss you",rick_3,comments);
		Person p1=new Person("Morty",morty);
		p1.addPost("Evil Plans","I got away with it",morty_0,comments);
		p1.addPost("PARRRTYYY!","Got HAMMERED last night!",morty_1,comments);
		p1.addPost("Hulk Musical!","Oh man I had to pee!",morty_2,comments);
		p1.addPost("Science Fair","Most stressful project ever!",morty_3,comments);
		p1.addWallPost (new string[]{ "hungry for apples?", "Rick" });
		p1.addWallPost (new string[]{ "because I am", "Rick" });
		p1.addWallPost (new string[]{ "why does no one love me", "Rick" });
		Person p2=new Person("Jerry",jerry);
		p2.addPost("Business!","My big proposal!",jerry_0,comments);
		p2.addPost("Paradise","The factory setting is always too high",jerry_1,comments);
		p2.addPost("Couples Therapy","Is this really how Beth sees me?",jerry_2,comments);
		p2.addWallPost (new string[]{ "hungry for apples?", "Morty" });
		p2.addWallPost (new string[]{ "because I am", "Morty" });
		p2.addWallPost (new string[]{ "why does no one love me", "Morty" });
		p2.addPost("Therapy Over","I am the best",jerry_3,comments);
		Person p3=new Person("Summer",summer);
		p3.addPost("Revenge","Me and Grandad dishing out some justice",summer_0,comments);
		p3.addPost("Family Time","Snuffles is a genius! xdd",summer_1,comments);
		p3.addPost("HEADS!","Free now headward to rise",summer_2,comments);
		p3.addPost("Tinkles","I told you all she was real!",summer_3,comments);
		p3.addWallPost (new string[]{ "slow down", "Bob" });
		p3.addWallPost (new string[]{ "My man", "Bob" });
		p3.addWallPost (new string[]{ "looking good", "Bob" });


		friends.Add (p0);
		friends.Add (p1);
		friends.Add (p2);
		friends.Add (p3);

		Debug.Log ("Friends: " + friends.Count);

		bool result = Frienterface.GetFriends((Texture tex, string name, string id) => {
			Debug.Log("Hi " + name);

			addFBFriend(tex,name,id);
		});

		Debug.Log ("HERP:" + result);

		updateViews ();
	}
	public void Start() {
		buildLists ();/*
		this.friends = new List<Person>();
		this.posts = new List<Post> ();

		Person p0=new Person("Rick",rick);
		p0.addPost("Saving Earth","Get Schwifty!",rick_0,comments);
		p0.addPost("Mug Shot","Got myself arrested...",rick_1,comments);
		p0.addPost("WUBALUBADUBDUB","I say it all the time guys",rick_2,comments);
		p0.addPost("Memories","RIP in peace Bird Person. I miss you",rick_3,comments);
		Person p1=new Person("Morty",morty);
		p1.addPost("Evil Plans","I got away with it",morty_0,comments);
		p1.addPost("PARRRTYYY!","Got HAMMERED last night!",morty_1,comments);
		p1.addPost("Hulk Musical!","Oh man I had to pee!",morty_2,comments);
		p1.addPost("Science Fair","Most stressful project ever!",morty_3,comments);
		Person p2=new Person("Jerry",jerry);
		p2.addPost("Business!","My big proposal!",jerry_0,comments);
		p2.addPost("Paradise","The factory setting is always too high",jerry_1,comments);
		p2.addPost("Couples Therapy","Is this really how Beth sees me?",jerry_2,comments);
		p2.addPost("Therapy Over","I am the best",jerry_3,comments);
		Person p3=new Person("Summer",summer);
		p3.addPost("Revenge","Me and Grandad dishing out some justice",summer_0,comments);
		p3.addPost("Family Time","Snuffles is a genius! xdd",summer_1,comments);
		p3.addPost("HEADS!","Free now headward to rise",summer_2,comments);
		p3.addPost("Tinkles","I told you all she was real!",summer_3,comments);


		friends.Add (p0);
		friends.Add (p1);
		friends.Add (p2);
		friends.Add (p3);

		Debug.Log ("Friends: " + friends.Count);

		bool result = Frienterface.GetFriends((Texture tex, string name, string id) => {
			Debug.Log("Hi " + name);

			addFBFriend(tex,name,id);
		});

		Debug.Log ("HERP:" + result);
*/
		updateViews ();
	}

	public DataModel()
	{
		// ..
	}
	public void addFBFriend(Texture t, string s, string id)
	{
		Person newPerson=new Person(s,t);

		friends.Add(newPerson);

		updateViews ();
	}
	public Person getRandomPerson()
	{
		System.Random random = new System.Random();
		int randomNumber = random.Next (0, friends.Count);

		return friends [randomNumber];
	}

	public void updateViews() {
		int c = this.frames.Count;

		for (int i = 0; i < c; ++i) {
			//Renderer rend = this.frames [i].GetComponent<Renderer> ();
			//Person p = getRandomPerson ();

			Debug.Log ("log testing " + i);

			//rend.material.mainTexture = rick;
			//rend.material.mainTexture = getRandomPerson ().getRandomPost ().content;

			//
			Post last = getRandomPerson ().getRandomPost ();
			int j = 0, k = 0;

			foreach (Transform child in frames [i].transform) {
				if (child.CompareTag ("comment")) {
					textToSurface script = child.GetComponents<textToSurface> ()[0];
					script.updateText (last.comments[j][1]);
					++j;
				}
				else if (child.CompareTag ("Pic")) {
					last = getRandomPerson ().getRandomPost ();
					j = 0;

					child.GetComponent<Renderer> ().material.mainTexture = last.content;
				}
			}
		}
	}
}
