using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Player_Name : NetworkBehaviour {

	[SyncVar]
	public string playerName = "Player";
	
	private Transform myTransform;
	
	public override void OnStartLocalPlayer()
	{
		CmdSetName(GameObject.Find("NetworkManager").GetComponent<NetworkManager_Custom>().playerName);
//		CmdSetName(GetComponent<PlayerCombat>().playerTypeStr);
	}
	
	void Awake () {
		myTransform = transform;
	}

	[Command]
	public void CmdSetName(string name)
	{
		this.playerName = name;
	}

	void OnGUI()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

	GUI.color = Color.black;
	GUI.Label(new Rect(pos.x-37, Screen.height - pos.y + 5, 110, 20), playerName);

	GUI.color = Color.white;
	GUI.Label(new Rect(pos.x-38, Screen.height - pos.y + 6, 110, 20), playerName);
	}
}
