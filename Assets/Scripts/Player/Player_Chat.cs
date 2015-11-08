using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Player_Chat : NetworkBehaviour {
	
	[SyncVar(hook="ChangeChat")]
	public string playerTest = "";
	
	string setName;
	
	bool flg = false;
	bool chatFlg = false;
	
	void Update ()
	{
		if (flg) {
			if (isLocalPlayer) {
				CmdSet (setName);
			}
			flg = false;
		}
	}
	
	public void SendChatText (string name)
	{
		if (isLocalPlayer) {
			Debug.Log(name);
			setName = name;
			flg = true;
		}
	}

	[Command]
	public void CmdSet(string name)
	{
		this.playerTest = name;
	}
	
	
	void ChangeChat(string str){
		playerTest = str;
	}

	void OnGUI ()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		
		if (playerTest.Length > 0) {
			GUI.Box (new Rect (pos.x + 25, Screen.height - pos.y - 145, 140, 70), "");
		}
			GUI.color = Color.black;
			GUI.Label (new Rect (pos.x + 31, Screen.height - pos.y - 140, 135, 65), playerTest);

			GUI.color = Color.white;
			GUI.Label (new Rect (pos.x + 30, Screen.height - pos.y - 141, 135, 65), playerTest);
		}
}
