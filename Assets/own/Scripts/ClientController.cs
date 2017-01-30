using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {
	
	public Character Character;
	public Request Request;
	public UiController Ui;

	private string name;
	private int drunkenness;
	private string message;

	/*
	 * Assign some initial properties and references to scene
	 */
	void Start () {
		name = gameObject.name;
		Character = new Character (name);
		drunkenness = 0;
		Ui = GameObject.FindGameObjectWithTag("DebugUI").GetComponent<UiController>();
		Invoke ("GenerateRequest", 1);
	}

	/*
	 * Determines what the client wants to drink
	 */
	private void GenerateRequest() {
		Request = new Request ();
		Ui.ReceiveChat (name + ": I would like to have a " + Request.Drink.Name + "\n");
	}
		
	/* 
	 * Will be called when Person gives client a drink
	 */
	public void GetDrink(Transform Drink) {
		bool isEquipment = Drink.IsChildOf (GameObject.Find ("Equipment").transform);
		if(isEquipment) {
			Dictionary<string, decimal> DrinkIngredients = Drink.GetComponent<DrinkController> ().DrinkIngredients;
			if (DrinkIngredients != null && DrinkIngredients.Count > 0) {
				TakeDrink (DrinkIngredients);
			} else {
				Debug.Log ("There's no damn drink in it!");
			}
		} else {
			TakeDrink(new Dictionary<string, decimal> () { { Drink.name, 200m } });
		}
	}

	/*
	 * If Drink matches process action
	 * 
	 * @return bool: RequestMatch
	 */
	private bool TakeDrink(Dictionary<string, decimal> Mix) {
		int rate = Request.RateMix(Mix);
		// Check if Ingredients from DrinkController match Ingredients of requested Drink
		if (Request.Match) {
			GiveMoney ();
			GenerateRequest ();
			return true;
		} else {
			Ui.ReceiveChat(name + ": That was not what I've ordered! :(\n");
			return false;
		}
	}

	/*
	 * Give price and calculated tip to bar tender 
	 */
	private void GiveMoney() {
		Request.CalculateTip (Character.Generousness[drunkenness]);
		int money = (int)Mathf.Round ((float)Request.Drink.Price + Request.Tip);
		Ui.ReceiveMoney (money);
		Ui.ReceiveChat(name + ": Thank you, sir! :)\n");		
	}

	/*
	 * Display smalltalk messages
	 */
	private void SmallTalk() {
		Debug.Log ("Do you want something from me?");
	}
}
