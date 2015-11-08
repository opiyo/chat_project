using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//static: 新しくインスタンス化しても変数の中身を保持する
//	public static GameManager instance;
	
	public string playerName;
	public int playerAvatar;
	
//	void Awake ()
//	{
//		if (instance != null) {
//			Destroy(this);
//		} else if (instance == null){
//			instance = this;
//		}
//
//		DontDestroyOnLoad (instance);
//	}

	public void SetName(string name)
	{
		playerName = name;
	}
	
	public void SetAvatar (int num)
	{
		playerAvatar = num;
	}
}