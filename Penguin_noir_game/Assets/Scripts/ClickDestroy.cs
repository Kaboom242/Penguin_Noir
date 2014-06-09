using UnityEngine;
using System.Collections;

public class ClickDestroy : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Destroy(gameObject);
		}
	}
}