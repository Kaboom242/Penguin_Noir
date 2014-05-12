using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Camera cam;
	public GameObject moveTarget;
	public float sprintSpeed;
	public float walkSpeed;
	public float walkRadius;
	private Vector3 newLoc;
	private bool canMove = true;
	NavMeshAgent agent;
	Animator anim;
	public GameObject character;
	public GameObject currentAi;
	public bool closeToAi;
	public GameObject charMesh;
	private bool clickedButton;
	
	// Use this for initialization
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
		anim = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentAi != null)
		{
			closeToAi = currentAi.GetComponent<WanderAi>().playerClose;
		}
		
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

		anim.SetFloat("Speed", agent.velocity.magnitude);

		if (Vector3.Distance(transform.position, moveTarget.transform.position) > walkRadius)
		{
			agent.speed = sprintSpeed;
		}
		else 
		{
			agent.speed = walkSpeed;
		}

		if (closeToAi == true)
		{
		
			//Vector3 lookDir;
			//lookDir = new Vector3(0, currentAi.transform.position.y, 0);
			//charMesh.transform.LookAt (lookDir);
			
		}
		else if ( closeToAi == false)
		{

		}

		
	
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

	public void AiClose (GameObject ai)
	{
		currentAi = ai;
	}
	
	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, walkRadius);
		
	}

	public void ClickedButton ()
	{
		agent.SetDestination (transform.position);


	}
	
}
