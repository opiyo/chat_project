using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu_StartButton : MonoBehaviour {

	public GameObject title;
	public GameObject inputPlayerNameText;
	public GameObject inputPlayerName;
	public GameObject inputPlayerNameButton;
	
	public void PushStart ()
	{
		title.SetActive(false);
		gameObject.SetActive(false);
		
		inputPlayerNameText.SetActive(true);
		inputPlayerName.SetActive(true);
		inputPlayerNameButton.SetActive(true);
	}
}