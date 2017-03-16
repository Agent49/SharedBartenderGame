using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Client : MonoBehaviour {

	private string name;
	private Character character;
	private Request request;
	private TextMesh chat;

	private decimal hasDrunk = 0m;
	private float orderTakeGap = 60f;	// TODO adjust

	private bool orderToLong = false;
	private bool toDrunk = false;

	// Use this for initialization
	void Start () {
		GameMaster.NumOfClients++;

		name = gameObject.name;
		chat = transform.GetChild (1).GetComponent<TextMesh> ();
		character = new Character (name);
		Chat (character.Say("hello"));
		OrderDrink ();
	}

	// Update is called once per frame
	void Update () {

		orderToLong = (
		    !request.Match &&
		    (Time.time > (request.OrderTime + orderTakeGap))
		);

		if (orderToLong || toDrunk)
			Leave ();
	}

	private void Chat(string message, bool append = false) {
		if (append)
			chat.text += "\n" + message;
		else
			chat.text = message;
	}

	public void OrderDrink(float orderDelay = 0.0f) {
		StartCoroutine (DelayedOrderDrink (orderDelay));
	}

	IEnumerator DelayedOrderDrink(float orderDelay) {
		yield return new WaitForSeconds(orderDelay);
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
		hasDrunk += request.ReceivedDrink.Volume;
		Debug.Log ("TakeDrink");
		Chat (character.Say (request.FeedBack), true);

		if (request.State == 5)
			hasDrunk -= 0.5m * request.ReceivedDrink.Volume;

		if (request.CalculateTip ())
			Chat (character.Say("tip"), true);

		GiveMoney ();
		IsToDrunken ();
		Debug.Log (hasDrunk);
		Debug.Log (character.Capacity);
		OrderDrink (delay);
		return 10f;
	}

	private float DenyDrink() {;
		Debug.Log ("DenyDrink");
		Chat (character.Say (request.FeedBack), true);
		return 5f;
	}

	private void GiveMoney() {
		Debug.Log ("Tip: " + request.Tip);
		GameMaster.MakeCash (request.RequestedDrink.Price + request.Tip);
	}

	private void Leave() {
		GameMaster.NumOfClients--;

		if (GameMaster.NumOfClients <= 0) {
			GameMaster.GameSession = false;
			GameMaster.EndGame ();
		}

		transform.gameObject.SetActive (false);
	}

	private bool IsToDrunken() {
		toDrunk = hasDrunk > character.Capacity;
		return toDrunk;
	}
}
