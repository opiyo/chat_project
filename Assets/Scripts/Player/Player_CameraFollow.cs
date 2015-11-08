using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Player_CameraFollow : NetworkBehaviour {

	Vector3 pos = new Vector3(15, 8, -20);
	
	void Update ()
	{
		if (!isLocalPlayer)
			return;
		
//		characterCam.transform.position = this.transform.position + pos;
		Camera.main.transform.position = this.transform.position + pos;
	}
}