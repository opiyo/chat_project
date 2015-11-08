using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;

public class JoinGame : NetworkBehaviour
{
	List<MatchDesc> roomList = null;

	NetworkManager manager;
	NetworkMatch networkMatch;
	
	void Start ()
	{
		manager = GetComponent<NetworkManager>();
//		networkMatch = gameObject.AddComponent<NetworkMatch>();
//		manager.StartMatchMaker();
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
	
	void OnGUI ()
	{
		
		if (GUI.Button (new Rect (10, 10, 200, 20), "部屋数更新")) {
			networkMatch.ListMatches (0, 10, "", OnMatchList);
		}
		
		if (roomList == null)
		{
			GUI.Label(new Rect(Screen.width/2 - 60, Screen.height/4, 100, 20), "Loading..");
		}
		else
		{
			int posY = Screen.height/4;
			foreach (var info in roomList)
			{
                if (GUI.Button(new Rect(Screen.width / 2 - 100, posY, 200, 20), "Join Game: " + info.name))
				{
					networkMatch.JoinMatch(info.networkId, "" , manager.OnMatchJoined);
					
					
				}
				posY += 25;
			}
		
		}
	}
	
//	public void OnMatchJoined(JoinMatchResponse matchJoin)
//    {
//        if (matchJoin.success)
//        {
//            Debug.Log("Join match succeeded");
//            if (matchCreated)
//            {
//                Debug.LogWarning("Match already set up, aborting...");
//                return;
//            }
//            Utility.SetAccessTokenForNetwork(matchJoin.networkId, new NetworkAccessToken(matchJoin.accessTokenString));
//            NetworkClient myClient = new NetworkClient();
//			
//			myClient.RegisterHandler(MsgType.Connect, OnConnected);
//            myClient.Connect(new MatchInfo(matchJoin));
//        }
//        else
//        {
//            Debug.LogError("Join match failed");
//        }
			
			
//    }
	
//	public void OnConnected(NetworkMessage msg)
//    {
//        Debug.Log("Connected!");
//    }
}
