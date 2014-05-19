using UnityEngine;
using System.Collections;

public class Cig : MonoBehaviour {

	public float duration = 1.0F;
	public Color color0;
	public Color color1;
	public ParticleSystem smoke;
	private bool canDrag;
	private bool lerpBack = false;
	private bool lerpForward;
	private Vector4 color0Vec;
	private Vector4 color1Vec;
	private Vector4 lightColor;
	private float t = 0;

	void Start()
	{
		Drag ();
	}
	void Update() 
	{
		color0Vec = color0;
		color1Vec = color1;
		lightColor = light.color;
		if (canDrag == true)
		{



			if (lerpForward == true)
			{
				t += Time.deltaTime;
				light.color = Color.Lerp(color0, color1, t * 0.5f);
				if (lightColor.x > 0.6f)
				{
					print ("switch");
					lerpBack = true;
					lerpForward = false;
					t = 0;
					smoke.Play();
				}
			}

			if (lerpBack == true)
			{
				t += Time.deltaTime;
				print ("back");

				light.color = Color.Lerp(color1, color0, t * 0.5f);
				if (lightColor.x < 0.15f)
				{
					print (lightColor.x);
					print("done");
					lerpBack = false;
					canDrag = false;
					t = 0;
				}
			}

		}
	}

	void Drag()
	{
		print ("Drag");
		t = 0;
		canDrag = true;
		lerpForward = true;
		smoke.Stop ();
		Invoke ("Drag", Random.Range (10, 15));
	}

}
