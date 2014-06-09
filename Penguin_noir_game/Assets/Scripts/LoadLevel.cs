using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	void OnMouseDown(){
		Application.LoadLevel ("CurrentLevel");
	}
}
