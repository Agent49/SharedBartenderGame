using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	// Singleton
	public static GameMaster GM;

	public static Transform Ingredients;

	void Awake() {
		if (GM != null)
			GameObject.Destroy (GM);
		else
			GM = this;

		DontDestroyOnLoad (this);
	}

	void Start() {
		Ingredients = GameObject.Find ("Ingredients").transform;
	}
}
