using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Linq;

public class GameMaster : MonoBehaviour {

	public static Transform ExitMenuUi;
	public static Transform SaveMenuUi;
	public static Transform HighscoreMenuUi;
	public static Transform HighScoreTable;
	public static InputField NameInput;

	public static Text HsNumber;
	public static Text HsName;
	public static Text HsDate;
	public static Text HsMoney;

	public static Transform Ingredients;
	public static TextMesh TillText;
	public static decimal Cash = 0.00m;

	public static float StartTime;
	private static bool gameSession { get; set; }
	private static bool gameStop{ get; set; }
	public static int NumOfClients { get; set; }

	public static SaveData saveData = new SaveData ();

	public static Text DebugText;

	void Awake() {
		NumOfClients = 0;
		StartTime = Time.time;
	}

	void Start() {
		Ingredients = GameObject.Find ("Ingredients").transform;

		DebugText = GameObject.Find ("DebugOutText").transform.GetComponent<Text> ();
		TillText = GameObject.Find ("TillText").transform.GetComponent<TextMesh>();

		ExitMenuUi = GameObject.Find ("ExitMenu").transform;
		SaveMenuUi = GameObject.Find ("SaveMenu").transform;
		HighscoreMenuUi = GameObject.Find ("HighscoreMenu").transform;
		HighScoreTable = GameObject.Find ("TableBody").transform;

		HsNumber = HighScoreTable.GetChild (0).GetComponent<Text> ();
		HsName = HighScoreTable.GetChild (1).GetComponent<Text> ();
		HsDate = HighScoreTable.GetChild (2).GetComponent<Text> ();
		HsMoney = HighScoreTable.GetChild (3).GetComponent<Text> ();

		NameInput = GameObject.Find("NameInput").GetComponent<InputField> ();

		ExitMenuUi.gameObject.SetActive (false);
		SaveMenuUi.gameObject.SetActive (false);
		HighscoreMenuUi.gameObject.SetActive (false);

		LoadScore ();
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Backspace))
			MenuSave ();

		if (SaveMenuUi.gameObject.activeSelf && Input.GetKeyDown (KeyCode.Return))
			SaveScore ();
	}

	public static void DebugOut(string debugText) {
		DebugText.text = debugText;
	}

	public static void MakeCash(decimal cash) {
		Cash += cash;
		TillText.text = Cash.ToString ("C");
	}
		
	public static void MenuSave() {
		SaveMenuUi.gameObject.SetActive (true);
		NameInput.Select ();
		NameInput.ActivateInputField ();
	}

	public static void MenuExit() {
		ExitMenuUi.gameObject.SetActive (true);
	}

	public static void MenuHighscore() {
		HighscoreMenuUi.gameObject.SetActive (true);
	}

	public static void LoadScore() {
		string json = PlayerPrefs.GetString ("highscores");
		saveData = JsonConvert.DeserializeObject<SaveData> (json);
	}

	public static void SaveScore() {
		Highscore highscore = new Highscore (
			saveData.Highscores.Count,
			NameInput.text,
			Cash,
			DateTime.Now.ToString()
		);

		saveData.Highscores.Add (highscore);
		string json = JsonConvert.SerializeObject (saveData);

		PlayerPrefs.SetString ("highscores", json);
		CreateHighscoreTable ();
		MenuHighscore ();
	}


	public static bool CreateHighscoreTable() {
		if (saveData.Highscores.Count <= 0)
			return false;

		List<Highscore> sortedHighscores = saveData.Highscores.OrderByDescending (o => o.Money).ToList();

		for(var i = 0; i < sortedHighscores.Count; i++) {
			HsNumber.text += (i + 1).ToString() + "\n";
			HsName.text += sortedHighscores [i].Name + "\n";
			HsDate.text += sortedHighscores [i].Date + "\n";
			HsMoney.text += sortedHighscores [i].Money.ToString() + "\n";
		}

		return true;
	}

	public static void EnterToilet() {
		
	}
}
