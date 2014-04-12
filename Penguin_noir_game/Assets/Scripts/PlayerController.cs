using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Camera cam;
	public GameObject moveTarget;
	private Vector3 newLoc;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),  out hit, 100))
				return;
				newLoc = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
				Debug.Log(hit.point);
				Debug.Log(newLoc);
			moveTarget.transform.position = newLoc;
			
			iTweenEvent.GetEvent(gameObject, "Move").Play();
			
			
		}
		
	
	}
}
