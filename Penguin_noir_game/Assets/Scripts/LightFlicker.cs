using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour {
	
	private List<Light> myLites = new List<Light>();
	
	public float time;
	public float startFlick;
	public bool on = true;

	public float rate;
	public int nextNum;

	public Light lite1;
	public Light lite2;
	public Light lite3;
	public Light lite4;
	public Light lite5;
	public Light lite6;
	public Light lite7;
	public Light lite8;
	public Light lite9;
	public Light lite10;


	// Use this for initialization
	void Start () 
	{

		Debug.Log (myLites.Count);
	
		myLites.Add (lite1);
		myLites.Add (lite2);
		myLites.Add (lite3);
		myLites.Add (lite4);
		myLites.Add (lite5);
		myLites.Add (lite6);
		myLites.Add (lite7);
		myLites.Add (lite8);
		myLites.Add (lite9);
		myLites.Add (lite10);

		Debug.Log (myLites.Count);
	}
	
	// Update is called once per frame
	void Update () 
	{
		time -= Time.deltaTime;
	
		
		if(time <= rate/2f)
		{
			myLites[nextNum].enabled = false;
			on = false;
		}
		
		if (time <= 0) 
		{
			if (nextNum == 9)
			{
					time = rate;
					nextNum = 0;
					
			}
			else{
					time = rate;
					
					if (!on)
					{
						myLites[nextNum].enabled = true;
						on = true;
					}

					nextNum++;
			}
		}
	}
}