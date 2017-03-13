using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Client : MonoBehaviour {

	private string name;
	private Character character;
	private Request request;
	private TextMesh chat;

	// Use this for initialization
	void Start () {
		name = gameObject.name;
		chat = transform.GetChild (1).GetComponent<TextMesh> ();
		character = new Character (name);
		Chat (character.Say("hello"));
		OrderDrink ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void Chat(string message, bool append = false) {
		if (append)
			chat.text += message;
		else
			chat.text = message;
	}

	public void OrderDrink() {
		request = new Request ();
		Chat (character.Say ("order") + request.RequestedDrink.Name);
		Debug.Log (request.RequestedDrink.ToString());
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
