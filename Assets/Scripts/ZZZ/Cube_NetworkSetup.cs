using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Cube_NetworkSetup : NetworkBehaviour {

	void Start ()
	{
		if (isLocalPlayer) {
			gameObject.GetComponent<Move>().enabled = true;
		}
	}
}
