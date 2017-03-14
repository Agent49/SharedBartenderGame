using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class GameMaster : MonoBehaviour {

	public static Transform SaveScoreMenu;
	public static InputField NameInput;

	public static Transform Ingredients;
	public static TextMesh TillText;
	public static decimal Cash = 0.00m;

	public static SaveData saveData = new SaveData ();

	public static Text DebugText;

	void Start() {
		SaveScoreMenu = GameObject.Find ("SaveScoreMenu").transform;
		Ingredients = GameObject.Find ("Ingredients").transform;
		DebugText = GameObject.Find ("DebugOutText").transform.GetComponent<Text> ();
		TillText = GameObject.Find ("TillText").transform.GetComponent<TextMesh>();

		NameInput = GameObject.Find("NameInput").GetComponent<InputField> ();

		SaveScoreMenu.gameObject.SetActive (false);

		LoadScore ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Backspace))
			ShowSaveScoreMenu ();

		if (SaveScoreMenu.gameObject.activeSelf && Input.GetKeyDown (KeyCode.Return))
			SaveScore ();
	}

	public static void DebugOut(string debugText) {
		DebugText.text = debugText;
	}

	public static void MakeCash(decimal cash) {
		Cash += cash;
		TillText.text = Cash.ToString ("C");
	}
		
	public static void ShowSaveScoreMenu() {
		SaveScoreMenu.gameObject.SetActive (true);
		NameInput.Select ();
		NameInput.ActivateInputField ();
	}

	public static void LoadScore() {
		string json = PlayerPrefs.GetString ("highscores");
		Debug.Log (json);
		saveData = JsonConvert.DeserializeObject<SaveData> (json);
	}

	public static void SaveScore() {
		Debug.Log (NameInput.text);
		Debug.Log (DateTime.Now.ToString ());
		Highscore highscore = new Highscore (
			saveData.Highscores.Count,
			NameInput.text,
			Cash,
			DateTime.Now.ToString()
		);

		saveData.Highscores.Add (highscore);
		string json = JsonConvert.SerializeObject (saveData);

		PlayerPrefs.SetString ("highscores", json);
	}

	public static void ShowScore() {
		
	}

	public static void EnterToilet() {
		
	}
}
