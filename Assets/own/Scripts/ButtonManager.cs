using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	public void OnExit() {
		Debug.Log ("Exit");
	}

	public void OnContinue() {
		Debug.Log ("Continue");
	}

	public void OnRestart() {
		Debug.Log ("Restart");
	}
}