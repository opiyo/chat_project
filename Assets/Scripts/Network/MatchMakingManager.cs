using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;
using System.Collections.Generic;

public class MatchMakingManager: NetworkBehaviour 
{
	private NetworkManager_Custom manager_;
    private NetworkMatch match_;

    public string matchName = "hogakumura";
    public uint matchSize = 100U;
	
	List<MatchDesc> roomList = null;
	
	public bool connect = false;
	bool firstFlg = false;
	bool secondFlg = false;

    void Start()
    {
		//NetworkManager_Custom取得
		manager_ = GetComponent<NetworkManager_Custom>();
		Debug.Log(manager_);
		
		//マッチメイクの準備
		Debug.Log("Start Match Maker");
		manager_.StartMatchMaker();
		manager_.matchName = matchName;
		manager_.matchSize = matchSize;
		match_ = manager_.matchMaker;
    }

    void Update ()
	{
		//Menu_PlayerNameButtonでボタンが押された時true
		if (connect) {
			if (!firstFlg) {
				List<MatchDesc> roomList = null;
				match_.ListMatches (0, 10, "", manager_.OnMatchList);
				firstFlg = true;
			}

			if (manager_.matches != null && !secondFlg) {
//			
				if (manager_.matches.Count == 0) {
					CreateRoom ();
				} else {
					JoinRoom ();
				}
				secondFlg = true;
			}
		}
	}
	
	void CreateRoom ()
	{
		Debug.Log ("Create Room");
		match_.CreateMatch (manager_.matchName, manager_.matchSize, true, "", manager_.OnMatchCreate);
	}
	
	void JoinRoom ()
	{
			Debug.Log ("Join Match");
		var desc = manager_.matches [0];
			match_.JoinMatch (desc.networkId, "", manager_.OnMatchJoined);
	}
	
	
	
	public void OnMatchList(ListMatchResponse matchList)
	{
        if (matchList == null)
        {
            Debug.Log("null Match List returned from server");
            return;
        }

        roomList = new List<MatchDesc>();
		roomList.Clear();
        foreach (MatchDesc match in matchList.matches)
		{
			roomList.Add(match);
		}
	}
}