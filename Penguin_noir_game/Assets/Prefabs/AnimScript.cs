using UnityEngine;
using System.Collections;

public class AnimScript : MonoBehaviour {

	private Animator annie;

	public float timer;

	public int minrang;
	public int maxrang;
	

	// Use this for initialization
	void Start () 
	{
		annie = gameObject.GetComponent<Animator>();

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

		if (Input.GetKey (KeyCode.Space)) 
		{
			annie.SetBool("IsRunning", true);
		}else
		{ 
			annie.SetBool("IsRunning", false);
		}
	}



}
