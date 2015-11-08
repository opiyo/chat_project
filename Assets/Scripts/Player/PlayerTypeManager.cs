using UnityEngine;
using System.Collections;

public class PlayerTypeManager : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		singleton = this;
	}
	
	static PlayerTypeManager singleton;

	public PlayerType[] players;
	
	public int playerTypeNum;
	
	static public PlayerType Random()
	{
		int index = UnityEngine.Random.Range(0,singleton.players.Length);
		return singleton.players[index];
	}
	
	static public PlayerType Lookup(string name)
	{
		Debug.Log(name);
		foreach (var pt in singleton.players)
		{
			if (pt.playerTypeName == name)
				return pt;
		}
		return null;
	}
}