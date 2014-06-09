using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {

	public bool item = false;
	public bool isTalking;
	public List<string> l_dialogue;
	public List<string> hasItem;
	GameObject dialogueBox;
	public GameObject textbox;
	public GameObject nameBox;

	void Start()
	{

		dialogueBox = GameObject.Find ("Dialogue");
		textbox = GameObject.Find ("Dialouge Text");
		nameBox = GameObject.Find ("NameText");
		#region Start game
		//1 , 3

		//Officer Tell you what to do (1)
		l_dialogue.Add ("Dective Penguin:");
		l_dialogue.Add ("I am a Penguin. Quack!");
		l_dialogue.Add ("Dective Penguin:");
		l_dialogue.Add ("I am here to solve a murder");


		//starting at found the mrs (3)
		l_dialogue.Add ("Damsel:");
		l_dialogue.Add ("I geev you sex baby, if you help me solve the murder.");
		l_dialogue.Add ("Damsel:");
		l_dialogue.Add("You're going to need an item");

		//talking to banker (6)
		l_dialogue.Add ("Dective Penguin:");
		l_dialogue.Add ("I am here to solve a murder for the sex");
		l_dialogue.Add("You're going to need an item");
		l_dialogue.Add ("Dective Penguin:");
		l_dialogue.Add ("I am here to solve a murder for the sex");
		l_dialogue.Add("You're going to need an item");

		//Has tem talks to lady (1)
		hasItem.Add ("The Banker:");
		hasItem.Add("Oh I noticed that you have a kniofe!!");
		hasItem.Add ("The Banker:");
		hasItem.Add("I give up. You solved the case. Here is sex");

		//has item talks to banker(3)
		hasItem.Add ("The Banker:");
		hasItem.Add("Oh I noticed that you have a kniofe!!");
		hasItem.Add ("The Banker:");
		hasItem.Add("I give up. You solved the case. Here is sex");
		#endregion 
		//4





		 
	}
	public void Talk(int i)
	{
		//IF YOU HAVE AN ITEM OR NOT
//		if (!item) {
//
//						//PLAYS THE NAME FIRST THEN DIALOG
//						InpuText (l_dialogue [i - 1], l_dialogue [i]);
//				} else if (item == true) {
//						InpuText (hasItem [i - 1], hasItem [i]);
//				}
		InpuText (l_dialogue [i - 1], l_dialogue [i]);
		TweenAlpha twnpos = dialogueBox.GetComponent("TweenAlpha") as TweenAlpha; 
		isTalking = true;
		twnpos.PlayReverse();
		Debug.Log ("WE HAVE TALKING");
	}

	//SEND TEXT NAME AND DIALOG TO GUI
	void InpuText(string name, string body)
	{
		UILabel textboxtext = textbox.GetComponent ("UILabel") as UILabel;
		UILabel nameboxtext = nameBox.GetComponent ("UILabel") as UILabel;
		textboxtext.text = body;
		nameboxtext.text = name;
		Debug.Log("We have name and Speech");
	}

}
