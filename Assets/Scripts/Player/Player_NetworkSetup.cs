using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour {

	void Start ()
	{
		if (isLocalPlayer) {
			gameObject.GetComponent<AudioListener>().enabled = true;
		}
	}
}