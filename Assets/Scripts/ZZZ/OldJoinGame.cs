using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class OldJoinGame : MonoBehaviour {

	List<MatchDesc> roomList = null;
	
	NetworkManager manager;
	NetworkMatch networkMatch;
	
	void Start ()
	{
		manager = NetworkManager.singleton;
		networkMatch = gameObject.AddComponent<NetworkMatch>();
	}
	
	public void OnMatchList(ListMatchResponse matchList)
	{
        if (matchList == null)
        {
            Debug.Log("部屋数は0です");
            return;
        }
		roomList = new List<MatchDesc>();
		roomList.Clear();
        foreach (MatchDesc match in matchList.matches)
		{
			roomList.Add(match);
		}
	}
	
	void OnGUI ()
	{
		if (GUI.Button (new Rect (10, 10, 200, 20), "部屋数更新")) {
			networkMatch.ListMatches (0, 10, "", OnMatchList);
		}
		
		
		if (roomList == null) {
			GUI.Label (new Rect (Screen.width / 2 - 60, Screen.height / 4, 100, 20), "部屋数は0です");
		} else {
			//部屋リストを取得する
			roomList = new List<MatchDesc>();
			networkMatch.ListMatches(0, 10, "", OnMatchList);
			
			int posY = Screen.height / 4;
			foreach (var info in roomList) {
				if (GUI.Button (new Rect (Screen.width / 2 - 100, posY, 200, 20), "Join Game: " + info.name)) {
					networkMatch.JoinMatch (info.networkId, "", manager.OnMatchJoined);
				}
				posY += 25;
			}
		}
	}
}