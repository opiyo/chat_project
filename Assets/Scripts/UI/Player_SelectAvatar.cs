using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_SelectAvatar : MonoBehaviour {

	private GameManager gameManager;
	
	public GameObject goyomatsu;
	
	
	void Start ()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		if (gameManager.playerAvatar == 1) {
			GameObject obj = Instantiate(goyomatsu, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			obj.transform.parent = this.gameObject.transform;
		}
	}
	
	void Update () {
	
	}
}
