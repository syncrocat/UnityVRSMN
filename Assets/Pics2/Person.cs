using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{		
	public List<Post> posts = new List<Post> ();
	public string name;
	public Texture profPic;
	public List<string[]> wall=new List<string[]>();
	public List<string[]> conversation=new List<string[]>();
	public bool isFriend=false;
	public Person (string nm,Texture pp)
	{
		name=nm;
		profPic=pp;
	}
	public void addPost(string t,string d, Texture c, string[][] comments)
	{
		Post newPost= new Post(t,c,d);
		foreach (string[] comment in comments)
		{
			newPost.addComment (comment);
		}
		posts.Add(newPost);
	}
	public void addWallPost(string[]wp)
	{
		wall .Add(wp);
	}
	
	public void addMessage(string[]newMess)
	{
		conversation.Add(newMess);
	}
	public Post getRandomPost()
	{
		System.Random random = new System.Random();
		int randomNumber = random.Next (0, posts.Count);

		return posts [randomNumber];
	}
	public void addFriend()
	{
		isFriend=true;
	}
}