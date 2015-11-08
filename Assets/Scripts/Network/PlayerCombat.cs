using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class PlayerCombat : NetworkBehaviour {

	public PlayerType pt;
	
	[SyncVar]
	public string playerTypeStr;
	
	[SyncVar]
	public Material playerMaterial;
	
	[Server]
	public void InitializeFromPlayerType (PlayerType newPT)
	{
		pt = newPT;
		playerTypeStr = pt.playerTypeName;
		playerMaterial = pt.playerMaterial;
		
		//手足にもMaterial付ける
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer ren in renderers) {
			ren.material = playerMaterial;
		}
	}
	
	public override void OnStartClient()
	{
		if (NetworkServer.active)
			return;
			
		//TODO
		PlayerType pt = PlayerTypeManager.Lookup(playerTypeStr);

		playerMaterial = pt.playerMaterial;
		
		//手足にもMaterial付ける
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> ();
		foreach (Renderer ren in renderers) {
			ren.material = playerMaterial;
		}
	}
}
