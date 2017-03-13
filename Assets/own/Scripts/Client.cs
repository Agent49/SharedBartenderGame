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

	public void OrderDrink(float orderTime = 0.0f) {
		StartCoroutine (DelayedOrderDrink (orderTime));
	}

	IEnumerator DelayedOrderDrink(float orderTime) {
		yield return new WaitForSeconds(orderTime);
		request = new Request ();
		Chat (character.Say ("order") + request.RequestedDrink.Name);
		Debug.Log (request.RequestedDrink.ToString());		
	}

	public float GetDrink(Collider other) {
		// Is container? Contains anything? Was is the right drink?
		if (request.Receive (other))
			return TakeDrink ();
		else
			return DenyDrink ();
	}

	private float TakeDrink() {
		float delay = (float)request.ReceivedDrink.Volume * 0.02f;
		Debug.Log ("TakeDrink");
		OrderDrink (delay);
		return 10f;
	}

	private float DenyDrink() {;
		Debug.Log ("DenyDrink");
		return 5f;
	}
}
