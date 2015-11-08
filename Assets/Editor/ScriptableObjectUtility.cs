using UnityEngine;
using UnityEditor; //エディター拡張関連
using System.IO; //ファイルの読み込み・書き込み

public static class ScriptableObjectUtility
{
	/// <summary>
	//	This makes it easy to create, name and place unique new ScriptableObject asset files.
	/// </summary>
	//ScriptableObjectの継承
	public static void CreateAsset<T> () where T : ScriptableObject
	{
		//インスタンス化
		T asset = ScriptableObject.CreateInstance<T> ();
		
		//ScriptableObject保存先のPathを作成
		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath ("Assets/PlayerTypes/" + typeof(T).ToString() + ".asset");
		
		//クリエイト→セーブ→フォーカス→インスタンスのアクティブ化
		AssetDatabase.CreateAsset (asset, assetPathAndName);
		AssetDatabase.SaveAssets ();
		EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;
	}
	
	//Assetメニューから新規作成
	[MenuItem("Assets/Create/PlayerType")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<PlayerType> ();
	}
}