using UnityEngine;
using System.Collections;

public class Cig : MonoBehaviour {

	public float duration = 1.0F;
	public Color color0;
	public Color color1;
	public  bool canDrag;

	void Start()
	{
		Drag ();
	}
	void Update() 
	{
		if (canDrag == true)
		{
			float t = Mathf.PingPong(Time.time, duration) / duration;
			light.color = Color.Lerp(color0, color1, t);
			if (light.color == color1)
			{
				canDrag = false;
			}
		}
	}

	void Drag()
	{
		print ("Drag");
		canDrag = true;
		Invoke ("Drag", Random.Range (10, 20));
	}

}
