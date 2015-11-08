using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputField_Chat : MonoBehaviour {

	Player_Chat player_test;

	private string str;
	private Text text;
	
	public void InputCheck ()
	{
			if (GetComponent<InputField> ().text.Contains ("\n") || (GetComponent<InputField> ().text.Length >= 40 
			&& (Input.GetKeyDown(KeyCode.Return)))) {
				GetComponent<InputField> ().text = GetComponent<InputField> ().text.Replace("\n","");
				Talk ();
			}
	}
	
	public void Talk ()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		string inputFieldText = this.GetComponent<InputField> ().text;
		foreach (GameObject obj in players) {
			obj.GetComponent<Player_Chat>().SendChatText(inputFieldText);
		}
		GetComponent<InputField> ().text = "";
	}
}