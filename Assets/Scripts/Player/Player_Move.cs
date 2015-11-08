using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Player_Move : NetworkBehaviour {
	
	public bool moving = false;
	public int dirY = 0;

	public float moveSpeed = 0.1f;

	private bool isFlick;
	Vector3 touchStartPos;
	Vector3 touchEndPos;
	
	private Main_SwitchButton button;
	
	void Start () {
		//button = GameObject.Find("Button").GetComponent<Main_SwitchButton>();
	}
	
	void Update ()
	{
		if (!isLocalPlayer) {
			return;
		}
		
		int oldDirY = dirY; 
		moving = false;
		
		//if (!button.playingFlg) {
		
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				//開始点保存
				touchStartPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
					Input.mousePosition.z);
				isFlick = true;
			}
			//押しっぱなし
			if (Input.GetKey (KeyCode.Mouse0)) {
				//終了地点保存
				touchEndPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
					Input.mousePosition.z);
				
				if (IsFlick ()) {
					Debug.Log ("moving!");
					float directionX = touchEndPos.x - touchStartPos.x;
					float directionY = touchEndPos.y - touchStartPos.y;
					
					//Xの変化量のほうが大きかったら
					if (Mathf.Abs (directionY) < Mathf.Abs (directionX)) {
						if (0 < directionX) {
							moving = true;
							Debug.Log ("Flick : Right");
							dirY = 90;
						} else {
							moving = true;
							Debug.Log ("Flick: Left");
							dirY = -90;
						}
					} else if (Mathf.Abs (directionX) < Mathf.Abs (directionY)) {
						if (0 < directionY) {
							moving = true;
							Debug.Log ("Flick : Up");
							dirY = 0;
						} else {
							moving = true;
							Debug.Log ("Flick : Down");
							dirY = 180;
						}
					}
				}
			}
		
			//フリック終了時
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				isFlick = false;
			}

//		if (Input.GetKey(KeyCode.LeftArrow))
//		{
//			dirY =  -90; 
//			moving = true;
//		}
//		if (Input.GetKey(KeyCode.RightArrow))
//		{
//			dirY = 90;
//			moving = true;
//		}
//		if (Input.GetKey(KeyCode.UpArrow))
//		{
//			dirY = 0;
//			moving = true;
//		}
//		if (Input.GetKey(KeyCode.DownArrow))
//		{
//			dirY = 180;
//			moving = true;
//		}
			
			if (dirY != oldDirY) {
				transform.eulerAngles = new Vector3 (0, dirY, 0);
			}
//		} else {
//			dirY = 180;
//			transform.eulerAngles = new Vector3 (0, dirY, 0);
//		}
			
	}
	 
	public void FixedUpdate()
	{
		 if(moving){
			transform.Translate(0, 0, moveSpeed);
		}
	}
	
	
	
	
	
	
	public void FlickOff()
	{
		isFlick = false;
	}
	
	public bool IsFlick()
	{
		return isFlick;
	}
}