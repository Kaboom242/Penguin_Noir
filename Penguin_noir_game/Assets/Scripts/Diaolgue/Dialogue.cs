using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour {
	public bool isTalking;
	public List<string> dialogue;

	GameObject dialogueBox;
	GameObject textbox;
	GameObject nameBox;

	void Start()
	{
		dialogueBox = GameObject.Find ("Dialogue");
		textbox = GameObject.Find ("Dialouge Text");
		nameBox = GameObject.Find ("NameText");
		#region Start game
		//1 , 3
		dialogue.Add ("Dective Penguin:");
			dialogue.Add ("I am a Penguin. Quack!");
		dialogue.Add ("Dective Penguin:");
			dialogue.Add ("I am here to solve a murder");
		dialogue.Add ("Dective Penguin:");
			dialogue.Add ("I am here to solve a murder for the sex");
		#endregion 
		//4

		 
	}
	public void Talk(int i)
	{
		InpuText (dialogue[i-1], dialogue[i]);
		TweenAlpha twnpos = dialogueBox.GetComponent("TweenAlpha") as TweenAlpha; 
		isTalking = true;
		twnpos.PlayForward();
	}
	void InpuText(string name, string body)
	{
		UILabel textboxtext = textbox.GetComponent ("UILabel") as UILabel;
		UILabel nameboxtext = nameBox.GetComponent ("UILabel") as UILabel;
		textboxtext.text = body;
		nameboxtext.text = name;
	}

}
