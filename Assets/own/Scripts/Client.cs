using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour {

	private Request request;

	// Use this for initialization
	void Start () {
		request = new Request ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float GetDrink(Collider other) {
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();

		if (drinkContainer != null)
			return TakeDrink (drinkContainer);
		else
			return DenyDrink();
	}

	private float TakeDrink(DrinkContainer drinkContainer) {
		request.Receive (drinkContainer);
		return 10f;
	}

	private float DenyDrink() {
		Debug.Log ("Deny");
		return 5f;
	}
}
