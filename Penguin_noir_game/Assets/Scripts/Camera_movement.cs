using UnityEngine;
using System.Collections;

public class Camera_movement : MonoBehaviour {
	public Transform Look_pos;
	public float posX;
	public float posZ;
	public float pos_up;
	void Update () {
		//Lerping sounds better
		Camera.main.gameObject.transform.position = new Vector3 (Look_pos.position.x + posX, pos_up, Look_pos.position.z + posZ);
	}
	void ScreenShake(){

	}
}
