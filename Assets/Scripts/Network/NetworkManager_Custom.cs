using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager_Custom : NetworkManager {

	public GameObject player;	
	private GameObject newPlayer; 
	
	public string playerName;
//	public int playerAvatarNo;
 
	//Spawn InfoのPlayer Prefabに登録しておく
    public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{
		Debug.Log("通ったよOnServerAddPlayer");
		newPlayer = GameObject.Instantiate (player);
		
		PlayerCombat pc = newPlayer.GetComponent<PlayerCombat>();
		pc.InitializeFromPlayerType(PlayerTypeManager.Random ());

		newPlayer.transform.position = new Vector3(10, 0, -15);

        NetworkServer.AddPlayerForConnection(conn, newPlayer, playerControllerId);
    }
}