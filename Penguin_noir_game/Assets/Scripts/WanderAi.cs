using UnityEngine;
using System.Collections;

public class WanderAi : MonoBehaviour {

	public float xRangeMax;
	public float xRangeMin;
	public float zRangeMax;
	public float zRangeMin;
	public float newSpotDistance;
	public bool atDestination = false;
	public float maxWaitTime;
	public float minWaitTime;
	public GameObject player;
	public bool playerClose;
	public GameObject charMesh;
	private float waitTime;
	private NavMeshAgent agent;
	
	
	// Use this for initialization
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination (new Vector3(Random.Range(xRangeMin,xRangeMax),transform.position.y,Random.Range(zRangeMin,zRangeMax)));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (atDestination == false && agent.remainingDistance < newSpotDistance)
		{
			waitTime = Random.Range(minWaitTime,maxWaitTime);
			Invoke("SetNewDestination",waitTime);
			Debug.Log("pausing");
			atDestination = true;
			
			
		}
		
		if (Vector3.Distance(transform.position, player.transform.position) < 2)
		{
			agent.SetDestination(transform.position);
			playerClose = true;
			player.GetComponent<PlayerController>().AiClose(gameObject);
		}
		else {
			playerClose = false;
		}
		
		if (playerClose == true)
		{
		
			charMesh.transform.rotation = Quaternion.Euler(new Vector3(0f, player.transform.rotation.y, 0f));
			Quaternion.Slerp(charMesh.transform.rotation, player.transform.rotation , Time.deltaTime);
		
		
		
		
		/*
			Vector3 newLook;
			
			newLook = new Vector3(0, player.transform.position.y, 0);
			
			charMesh.transform.LookAt (newLook); 
		*/
				
		}
		else if ( playerClose == false)
		{
			charMesh.transform.forward = Vector3.Slerp(charMesh.transform.forward, gameObject.transform.forward, Time.deltaTime);
			//charMesh.transform.rotation = Quaternion.identity;
		}
		
//		else if (Vector3.Distance(transform.position, player.transform.position) > 2)
//		{
//			SetNewDestination();
//		}
	}
	
	void SetNewDestination ()
	{
		agent.SetDestination (new Vector3(Random.Range(xRangeMin,xRangeMax),transform.position.y,Random.Range(zRangeMin,zRangeMax)));
		Debug.DrawRay(agent.destination, Vector3.up, Color.red, 10, true);
		atDestination = false;
	}

	void OnDrawGizmosSelected() 
	{
			Gizmos.color = Color.blue;
		Gizmos.DrawLine(new Vector3(xRangeMin,transform.position.y, zRangeMin), new Vector3(xRangeMax,transform.position.y, zRangeMin));
		Gizmos.DrawLine(new Vector3(xRangeMax,transform.position.y, zRangeMin), new Vector3(xRangeMax,transform.position.y, zRangeMax));
		Gizmos.DrawLine(new Vector3(xRangeMax,transform.position.y, zRangeMax), new Vector3(xRangeMin,transform.position.y, zRangeMax));
		Gizmos.DrawLine(new Vector3(xRangeMin,transform.position.y, zRangeMax), new Vector3(xRangeMin,transform.position.y, zRangeMin));

	}
	
	
}
