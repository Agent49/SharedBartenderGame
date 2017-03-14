using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	public static Transform SaveScoreMenu;
	public static InputField NameInput;

	public static Transform Ingredients;
	public static TextMesh TillText;
	public static decimal Cash = 0.00m;

	public static Text DebugText;

	void Start() {
//		SaveScoreMenu = GameObject.Find ("SaveScoreMenu").transform;
		Ingredients = GameObject.Find ("Ingredients").transform;
		DebugText = GameObject.Find ("DebugOutText").transform.GetComponent<Text> ();
		TillText = GameObject.Find ("TillText").transform.GetComponent<TextMesh>();

		NameInput = GameObject.Find("NameInput").GetComponent<InputField> ();

//		SaveScoreMenu.gameObject.SetActive (false);
	}

	void Update() {
//		if (Input.GetKeyDown (KeyCode.Backspace))
//			ShowSaveScoreMenu ();
//
//		if (SaveScoreMenu.gameObject.activeSelf && Input.GetKeyDown (KeyCode.Return))
//			SaveScore ();
	}

	public static void DebugOut(string debugText) {
		DebugText.text = debugText;
	}

	public static void MakeCash(decimal cash) {
		Cash += cash;
		TillText.text = Cash.ToString ("C");
	}
		
	public static void ShowSaveScoreMenu() {
//		SaveScoreMenu.gameObject.SetActive (true);
//		NameInput.Select ();
//		NameInput.ActivateInputField ();
	}

	public static void SaveScore() {
		Debug.Log (NameInput.text);
	}

	public static void EnterToilet() {
		
	}
}
