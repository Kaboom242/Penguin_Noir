using UnityEngine;
using System.Collections;

public class WanderAi : MonoBehaviour {

	public float xRangeMax;
	public float xRangeMin;
	public float yRangeMax;
	public float yRangeMin;
	public float newSpotDistance;
	public bool atDestination = false;
	public float pauseTime;
	private float waitTime;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () 
	{
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.SetDestination (new Vector3(Random.Range(xRangeMin,xRangeMax),transform.position.y,Random.Range(yRangeMin,yRangeMax)));
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (atDestination == false && agent.remainingDistance < newSpotDistance)
		{
			waitTime = Random.Range(1.5f,3f);
			Invoke("SetNewDestination",waitTime);
			Debug.Log("pausing");
			atDestination = true;
			
			
		}
	}
	
	void SetNewDestination ()
	{
		agent.SetDestination (new Vector3(Random.Range(xRangeMin,xRangeMax),transform.position.y,Random.Range(yRangeMin,yRangeMax)));
		Debug.DrawRay(agent.destination, Vector3.up, Color.red, 10, true);
		atDestination = false;
	}
	
	
}
