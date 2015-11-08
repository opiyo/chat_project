using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;
using System.Collections.Generic;

public class TestNetworkManager : NetworkManager {
	
	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
//		Vector3 pos = Vector3.zero;
//		pos.y += (conn.connectionId % 8)*2;
//		pos.x += ((conn.connectionId / 4)*4);
		
		 //base: 継承した親クラスへアクセス　playerPrefabはSpawn Infoのやつ
		GameObject thePlayer = (GameObject)Instantiate(base.playerPrefab, new Vector3(0,0,0), Quaternion.identity);
		PlayerCombat pc = thePlayer.GetComponent<PlayerCombat>();
//		pc.InitializeFromPlayerType(PlayerTypeManager.Random ());
		
		NetworkServer.AddPlayerForConnection(conn, thePlayer, playerControllerId);
	}
}
	
//	public GameObject newPlayer;
//	public GameObject Cube1;
//	public GameObject Cube2;
//	public GameObject Cube3;
//	
//	NetworkManager manager;
//	
//	void Start ()
//	{
//		manager = GetComponent<NetworkManager>();
//	}
//	
//	public void SetNum (int n)
//	{
//		if (n == 1) {
//			manager.playerPrefab = Cube1;
//			Debug.Log("Cube1");
//		} else if (n == 2) {
//			manager.playerPrefab = Cube2;
//			Debug.Log("Cube2");
//		}
//	}

//	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
//	{
//		if (num == 1) {
//			
//			newPlayer = GameObject.Instantiate (Cube1);
//			Debug.Log("Cube1");
//		} else if (num == 2) {
//			newPlayer = GameObject.Instantiate (Cube2);
//			Debug.Log("Cube2");
//		}
//		
////		NetworkServer.Spawn(newPlayer);
//		NetworkServer.AddPlayerForConnection(conn, newPlayer, playerControllerId);
//	}
	
	
//	public override void OnClientConnect (NetworkConnection conn)
//	{
//		Debug.Log ("OnClientConnect");
//		
//	}
//	public override void OnStartClient (NetworkClient client)
//	{
//		Debug.Log ("OnStartClient");
//		ClientScene.RegisterPrefab(Cube3);
////		client.RegisterHandler(MsgType.Connect, OnConnected);
//	}
//	public override void OnStopClient ()
//	{
//		Debug.Log ("OnStopClient");
//	}
//	public virtual void OnClientSceneChanged (NetworkConnection conn)
//	{	
//		Debug.Log("OnClientSceneChanged");
//	}
//	public virtual void OnClientNotReady (NetworkConnection conn)
//	{
//		Debug.Log("OnClientNotReady");
//	}
//}
