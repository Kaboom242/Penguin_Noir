using UnityEngine;
using System.Collections;

public class MouseClickBurst : MonoBehaviour
{
	public PlayerController PC;
	public ParticleSystem ParticleInstance;

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			ParticleSystem clone;
			clone = Instantiate(ParticleInstance, transform.position, transform.rotation) as ParticleSystem;
		}
	}
}