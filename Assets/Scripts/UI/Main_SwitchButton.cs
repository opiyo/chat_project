using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Main_SwitchButton : MonoBehaviour {
	
	Button button;
	public Sprite chatPic;
	public Sprite playPic;
	
	public GameObject inputField;
	public GameObject chatButton;
	public GameObject koto;
	public bool playingFlg = false;
	
	bool switchFlg = true;

	void Start () {
		button = gameObject.GetComponent<Button>();
	}
	
	public void ClickButton ()
	{
		switchFlg = !switchFlg;
		
		if (switchFlg == true) {
			ActiveChat();
		} else {
			ActivePlay();
		}
	}
	
	void ActiveChat()
	{
		button.image.sprite = chatPic;
		inputField.SetActive(true);
		chatButton.SetActive(true);
		koto.SetActive(false);
		playingFlg = false;
	}
	
	void ActivePlay()
	{
		button.image.sprite = playPic;
		inputField.SetActive(false);
		chatButton.SetActive(false);
		koto.SetActive(true);
		playingFlg = true;
		//kotoScript.playSound = false;
	}
}
