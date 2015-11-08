using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Menu_PlayerAvatarButton : MonoBehaviour {

	public NetworkManager_Custom networkManager;
	
	public GameObject playerAvatarText;
	public GameObject playerAvatarButton1;
	public GameObject playerAvatarButton2;
	public GameObject playerAvatarButton3;
	
	public GameObject playerNameText;
	public GameObject enterButton;
	public GameObject createButton;
	
	public MatchMakingManager matchMake;
	
	public void PushPlayerAvatar (int num)
	{
//		networkManager.playerAvatarNo = num;
		
		playerAvatarText.SetActive (false);
		
		if (num == 1) {
			playerAvatarButton2.SetActive (false);
			playerAvatarButton3.SetActive (false);
			
			RectTransform rt = GetComponent<RectTransform> ();
			rt.localPosition = new Vector2 (315, 0);
		} else if (num == 2) {
			playerAvatarButton1.SetActive (false);
			playerAvatarButton3.SetActive (false);
			
			RectTransform rt = GetComponent<RectTransform> ();
			rt.localPosition = new Vector2 (315, 0);
		} else if (num == 3) {
			playerAvatarButton1.SetActive (false);
			playerAvatarButton2.SetActive (false);
			
			RectTransform rt = GetComponent<RectTransform> ();
			rt.localPosition = new Vector2 (315, 0);
		}
		
		playerNameText.SetActive (true);
		playerNameText.GetComponent<Text> ().text = "名前： " + networkManager.playerName;
		
		enterButton.SetActive (true);
		createButton.SetActive (true);
		
//		if (matchMake.createFlg) {
//			enterButton.GetComponent<Button> ().interactable = false;
//		} else {
//			createButton.GetComponent<Button> ().interactable = false;
//		}
	}
}
