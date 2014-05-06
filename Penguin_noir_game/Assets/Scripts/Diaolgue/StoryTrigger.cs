using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryTrigger : Dialogue {

	public Dialogue dia;
	public GameObject diaBox;
	private int treeIndex = 0;


	public GameObject[] inventoryItem;


	public int NumSequance;
	public int play_x_Msg;

	public List<DialogueTextTrees> DialogueChoices;



	void Start()
	{
		foreach(DialogueTextTrees d in this.gameObject.GetComponents<DialogueTextTrees>()){
				DialogueChoices.Add(d);
		}
		diaBox = GameObject.Find("Dialogue");
		dia = diaBox.GetComponent("Dialogue") as Dialogue;
	}
	void Update()
	{
		if (Input.GetKey (KeyCode.Space)) {
			TweenAlpha tweenpos = diaBox.GetComponent("TweenAlpha") as TweenAlpha;
			dia.isTalking = false;
			tweenpos.PlayReverse();	
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			Debug.Log("I am Talking@!!!!");
			StartCoroutine(SayWhat(NumSequance, play_x_Msg));
		}
	}
	
	IEnumerator SayWhat(int i, int j)
	{
		int startI = i;
		while(i < startI + j){
			dia.Talk((2 * i - 1));
			while(dia.isTalking){
				yield return new WaitForSeconds(.1f);
			}
			yield return new WaitForSeconds(.5f);
			i = i + 1;
		}
		//show Dialogue Tree
		/*  Just Show the Dialogue Buttons and have them play thge SayWhat and reshow the Dialogue Buttons
		 * 
		 * 
		if (DialogueChoices.ToArray ().Length > 0) {
			if(treeIndex - 1 > DialogueChoices.ToArray ().Length)
			{
				SayWhat(DialogueChoices[treeIndex].Startloc, DialogueChoices[treeIndex].Xmsgs);
			}
		}
		*/
				
	}
}
