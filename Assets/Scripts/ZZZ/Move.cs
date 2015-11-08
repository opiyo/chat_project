using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {

	float moveSpeed = 5;
	
	void Update ()
	{
		float x = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		float z = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		
		transform.Translate (x, 0, z);
	}
}
