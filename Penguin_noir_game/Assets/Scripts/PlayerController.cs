using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(cam.transform.position, transform.position - cam.transform.position, 10));
			Debug.DrawRay(cam.transform.position, transform.position - cam.transform.position);
		}
	
	}
}
