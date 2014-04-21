using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Camera cam;
	public GameObject moveTarget;
	private Vector3 newLoc;
	private bool canMove = true;
	NavMeshAgent agent;
	Animator anim;
	public GameObject character;
	
	// Use this for initialization
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
		anim = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && canMove == true)
		{
			RaycastHit hit;
			if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),  out hit, 100))
				return;
				newLoc = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
				
			moveTarget.transform.position = newLoc;

			agent.SetDestination(moveTarget.transform.position);
			//iTweenEvent.GetEvent(gameObject, "Move").Play();
		}

		anim.SetFloat("Speed", agent.remainingDistance);
//		if (agent.remainingDistance < 0.8f)
//		{
//			agent.Stop();
//		}
		
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "Teleport")
		{
			canMove = false;
			cam.GetComponent<Camera_movement>().FadeOut(new Vector3 (-77, gameObject.transform.position.y,16.8f));
			
		}
		if (collider.gameObject.name == "TeleportBack")
		{
			canMove = false;
			cam.GetComponent<Camera_movement>().FadeOut(new Vector3 (-34, gameObject.transform.position.y,23));
			
		}
	}
	
	public void Teleport(Vector3 destination)
	{
		transform.position = destination;
		cam.GetComponent<Camera_movement>().FadeIn();
		agent.Warp(destination);
		canMove = true;
		
	}
}
