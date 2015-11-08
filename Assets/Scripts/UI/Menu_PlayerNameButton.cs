using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu_PlayerNameButton : MonoBehaviour {

	public NetworkManager_Custom networkManager;
	
	public GameObject inputPlayerNameText;
	public GameObject inputFieldPlayerName;
	public GameObject inputPlayerNameButton;
	
	public MatchMakingManager match;
	public GameObject connectingText;
	
	public void InputCheck ()
	{
		//改行コード有りor10文字以上でReturnキーを押したら実行
		if (GetComponent<InputField> ().text.Contains ("\n") || (GetComponent<InputField> ().text.Length >= 10 
		&& Input.GetKeyDown(KeyCode.Return))) {
			//改行コードは消す
			GetComponent<InputField> ().text = GetComponent<InputField> ().text.Replace("\n","");
			PushPlayerNameButton ();
		}
	}
	
	public void PushPlayerNameButton ()
	{
		if (inputFieldPlayerName.GetComponent<InputField> ().text.Length == 0) {
			Text ipn = inputPlayerNameText.GetComponent<Text>();
			ipn.text = "名前が入力されて\nいません";
			ipn.color = new Color(255,0,0,255);
			return;
		} else {
			networkManager.playerName = this.GetComponent<InputField> ().text;
			GetComponent<InputField> ().text = "";
			
			//Text,InputField, Buttonを非表示
			inputPlayerNameText.SetActive (false);
			inputPlayerNameButton.SetActive (false);
			inputFieldPlayerName.SetActive (false);
			
			match.connect = true;
			connectingText.SetActive(true);
		}
	}
}