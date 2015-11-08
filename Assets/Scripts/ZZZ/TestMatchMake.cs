using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;

public class TestMatchMake: MonoBehaviour 
{
    public NetworkManager manager_;
    private NetworkMatch match_;

    public string matchName = "hogehoge";
    public uint matchSize = 4U;

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Start Match Maker");
            manager_.StartMatchMaker();
            manager_.matchName = matchName;
            manager_.matchSize = matchSize;
            match_ = manager_.matchMaker;
        }
		if (match_ != null && Input.GetKeyDown(KeyCode.Alpha2)) {
            match_.CreateMatch(manager_.matchName, manager_.matchSize, true, "", manager_.OnMatchCreate);
        }
		if (match_ != null && Input.GetKeyDown(KeyCode.Alpha3)) {
            Debug.Log("List Matches");
            match_.ListMatches(0, 20, "", manager_.OnMatchList);
        }
		if (match_ != null && Input.GetKeyDown(KeyCode.Alpha4)) {
            Debug.Log("Join Match");
            var desc = manager_.matches[0]; // join first room  
			
			
            match_.JoinMatch(desc.networkId, "", manager_.OnMatchJoined);
//			match_.JoinMatch(desc.networkId, "", OnMatchJoinedAsClient);
        }
    }
	
	
	
//	public void OnMatchJoinedAsClient(JoinMatchResponse matchJoin){
//         //base.OnMatchJoined(matchJoin);
//         Debug.Log("OnMatchJoin as Client");
//		manager_.StartClient();
//     }
}