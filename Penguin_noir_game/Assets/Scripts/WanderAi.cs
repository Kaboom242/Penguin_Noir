using UnityEngine;
using System.Collections;

public class WanderAi : MonoBehaviour {

	public float xRangeMax;
	public float xRangeMin;
	public float yRangeMax;
	public float yRangeMin;
	public float newSpotDistance;
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
		if (agent.remainingDistance < newSpotDistance)
		{
			SetNewDestination();
		}
	}
	
	void SetNewDestination ()
	{
		
		agent.SetDestination (new Vector3(Random.Range(xRangeMin,xRangeMax),transform.position.y,Random.Range(yRangeMin,yRangeMax)));
		Debug.DrawRay(agent.destination, Vector3.up, Color.red, 10, true);
	}
}
