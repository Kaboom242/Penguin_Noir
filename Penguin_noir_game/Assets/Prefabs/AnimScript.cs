using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {

	public WanderAi WAi;
	public Animator annie;
	public GameObject Character;

	public float timer;

	public int minrang;
	public int maxrang;
	

	// Use this for initialization
	void Start () 
	{
		annie = Character.GetComponent<Animator>();
		WAi = gameObject.GetComponent<WanderAi>();
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			timer = Random.Range(minrang, maxrang);
			annie.SetInteger("SwitchPose", Random.Range(1, 8));
		}

		if (!WAi.atDestination) 
		{
			annie.SetBool("IsRunning", true);
			Debug.Log("WALKING AROUND");
		}else
		{ 
			annie.SetBool("IsRunning", false);
			Debug.Log("Hangin Around");
		}
	}



}
