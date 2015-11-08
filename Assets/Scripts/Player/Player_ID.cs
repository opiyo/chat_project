using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Player_ID : NetworkBehaviour {

	[SyncVar] public string playerID;
	
	private NetworkInstanceId playerNetID;
	
	private Transform myTransform;
	
	public Player_Name player_Name;
	
	public override void OnStartLocalPlayer()
	{
		GetNetIdentity();
		SetIdentity();
	}
	
	void Awake () {
		myTransform = transform;
	}
	
	void Update () {
		SetIdentity();
	}
	
	[Client]
	void GetNetIdentity()
	{
		playerNetID = GetComponent<NetworkIdentity>().netId;
		
		CmdTellServerMyIdentity(MakeUniqueIdentity());
	}
	
	void SetIdentity ()
	{
		if (!isLocalPlayer) {
			myTransform.name = playerID;
		} else {
			myTransform.name = MakeUniqueIdentity();
			player_Name.CmdSetName(myTransform.name);
		}
	}
	
	string MakeUniqueIdentity ()
	{
		string uniqueName = "Player " + playerNetID.ToString();
		return uniqueName;
	}
	
	[Command]
	void CmdTellServerMyIdentity (string name)
	{
		playerID = name;
	}
}
