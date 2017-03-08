using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {


	public static Transform Ingredients;

	void Start() {
		Ingredients = GameObject.Find ("Ingredients").transform;
	}
}
