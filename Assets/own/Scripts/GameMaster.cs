using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour {


	public static Transform Ingredients;
	public static TextMesh TillText;
	public static decimal Cash = 0.00m;

	public static Text DebugText;

	void Start() {
		Ingredients = GameObject.Find ("Ingredients").transform;
		DebugText = GameObject.Find ("DebugOutText").transform.GetComponent<Text> ();
		TillText = GameObject.Find ("TillText").transform.GetComponent<TextMesh>();
	}

	public static void DebugOut(string debugText) {
		DebugText.text = debugText;
	}

	public static void MakeCash(decimal cash) {
		Cash += cash;
		TillText.text = Cash.ToString ("C");
//		TillText.text = string.Format ("{0:C}", Cash);
	}
}
