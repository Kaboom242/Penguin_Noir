using UnityEngine;
using System.Collections;

public class StoryTrigger : Dialogue {

	private Dialogue dia;
	private GameObject diaBox;

	public GameObject[] inventoryItem;

	public string[] numberOfDialogueChoices;

	public int NumSequance;
	public int play_x_Msg;

	void Start()
	{
		diaBox = GameObject.Find ("Dialogue");
		dia = diaBox.GetComponent("Dialogue") as Dialogue;
	}
	void Update()
	{

	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.transform.root.name == "Hand"){
			StartTalking();
		}
	}

	void StartTalking()
	{
		StartCoroutine(SayWhat(NumSequance));
	
	}
	IEnumerator SayWhat(int i)
	{
		int startI = i;
		while(i < startI + play_x_Msg){
			dia.Talk((2 * i - 1));
			while(dia.isTalking){
				yield return new WaitForSeconds(.1f);
			}
			yield return new WaitForSeconds(.5f);
			i = i + 1;
		}
				
	}
}
