using UnityEngine;
using System.Collections;

public class Camera_movement : MonoBehaviour {
	public Transform Look_pos;
	public float posX;
	public float posZ;
	public float pos_up;
	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay;
	float shake_intensity;
	public float ShakeIT = .02f;
	public GameObject player;
	private bool isInside = false;
	private Vector3 teleportTo;
	
	void Start ()
		
	{
		
		//Make a default black color fade 
		
		iTween.CameraFadeAdd();
		
		
		
		//Fade from black:
		
		//iTween.CameraFadeFrom(iTween.Hash("amount",.5));
		
		
		
		
		
	}
	
	
	
	void OnGUI (){
		if (GUI.Button (new Rect (100,40,80,20), "Shake")){
			Shake ();
		}
	}
	
	void Update (){
		//Lerping sounds better
		Camera.main.gameObject.transform.position = new Vector3 (Look_pos.position.x + posX, pos_up, Look_pos.position.z + posZ);
		if (shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity,shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity,shake_intensity) * .2f);
			shake_intensity -= shake_decay;
		}
	}

	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_decay = 0.001f;
		shake_intensity = ShakeIT;
	}
	
	public void FadeOut(Vector3 location)
	{
		//Fade to black
		Debug.Log (location);
		iTween.CameraFadeTo(iTween.Hash("amount",.5,"time", 2, "onComplete","ToTeleport","onCompleteTarget",gameObject));
		teleportTo = location;
		
	}
	
	public void FadeIn()
	{
		//Fade from black:
		iTween.CameraFadeTo(iTween.Hash("amount",0));

	}
	
	void ToTeleport()
	{
		player.GetComponent<PlayerController>().Teleport(teleportTo);
		if (isInside == false)
		{
			camera.orthographicSize = 6.3f;
			isInside = true;
		}
		else if (isInside == true)
		{
			camera.orthographicSize = 12.24f;
			isInside = false;
		}
	}
}
