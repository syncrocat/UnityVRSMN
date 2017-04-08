using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Post
{
	
	public List<string[]> comments = new List<string[]> ();		
	public string title;
	public Texture content;
	public string description;
	public Post (string t, Texture c, string d )
	{
		title=t;
		content=c;
		description=d;
	}
	public void addComment(string[] text)
	{
		comments.Add(text);
	}
}