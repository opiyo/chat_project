using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System.Collections;

public class HostGame : MonoBehaviour
{
	NetworkMatch networkMatch;
	NetworkManager manager;
	
	void Start () {
		//自身にNetworkMatchコンポーネントを取り付ける
//		networkMatch = gameObject.AddComponent<NetworkMatch>();
//		manager = NetworkManager.singleton;
//		manager.StartMatchMaker();
		manager = GetComponent<NetworkManager>();
	}
	
	void OnGUI (){
		if (GUI.Button (new Rect (250, 20, 200, 20), "Create Room")) {
			//CreateMatchRequest: UNETにマッチメイキングを作らせるためのJSONオブジェクト
			CreateMatchRequest create = new CreateMatchRequest ();
			//部屋名
			create.name = "NewRoom";
			//人数
			create.size = 4;
			//部屋ができたことを知らせるか？
			create.advertise = true;
			//パスワード
			create.password = "";
			networkMatch = manager.matchMaker;
			//CreateMatch: create情報を持って、部屋を作ろうとしている
			//情報を元に部屋を作り、ホストとして実行
            networkMatch.CreateMatch(create, NetworkManager.singleton.OnMatchCreate);
		}
	}
}