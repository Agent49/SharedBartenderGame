using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {
	
	private string Name;
	public Character Character;
	public int Drunkenness;
	public Request Request;
	public string tmp;
	public string Message;
	public UiController Ui;

	void Start () {
		this.Name = this.gameObject.name;
		this.Character = new Character (this.Name);
		Ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UiController>();
		Invoke ("GenerateRequest", 1);
	}

	/*
	 * GenerateRequest(): Determines what the client wants to drink
	 */
	void GenerateRequest() {
		this.Request = new Request ();
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		Ui.ReceiveChat (this.Name + ": I would like to have a " + this.Request.Drink.Name + "\n");
	}
		
	/* 
	 * GetDrink: Will be called when Person gives client a drink
	 */
	void GetDrink(Transform Drink) {
		bool isEquipment = Drink.IsChildOf (GameObject.Find ("Equipment").transform);
		if(isEquipment) {
			Dictionary<string, decimal> DrinkIngredients = Drink.GetComponent<DrinkController> ().DrinkIngredients;
			if (DrinkIngredients != null && DrinkIngredients.Count > 0) {
				this.TakeDrink (DrinkIngredients);
			} else {
				Debug.Log ("There's no damn drink in it!");
			}
		} else {
			this.TakeDrink(new Dictionary<string, decimal> () { { Drink.name, 200m } });
		}
	}

	/*
	 * Will be called when Barkeeper gives a Drink to the client
	 * 
	 * @return bool: RequestMatch
	 */
	bool TakeDrink(Dictionary<string, decimal> Mix) {
		int rate = this.Request.RateMix(Mix);
		// Check if Ingredients from DrinkController match Ingredients of requested Drink
		if (this.Request.Match) {
			int tip = this.Request.CalculateTip ();
			Ui.ReceiveMoney (10);
			Ui.ReceiveChat(this.Name + ": Thank you, sir! :)\n");
			GenerateRequest ();
			return true;
		} else {
			Ui.ReceiveChat(this.Name + ": That was not what I've ordered! :(\n");
			return false;
		}
	}



	void AssessSatisfaction() {
		
	}


	void SmallTalk() {
		Debug.Log ("Do you want something from me?");
	}
}
