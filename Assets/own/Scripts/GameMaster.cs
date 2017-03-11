using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {


	public static Transform Ingredients;
	public static Transform DebugOutText;

	public static Text DebugText;

	void Start() {
		Ingredients = GameObject.Find ("Ingredients").transform;
		DebugOutText = GameObject.Find ("DebugOutText").transform;
		DebugText = DebugOutText.GetComponent<Text> ();
	}

	public static void DebugOut(string debugText) {
		DebugText.text = debugText;
	}
}
