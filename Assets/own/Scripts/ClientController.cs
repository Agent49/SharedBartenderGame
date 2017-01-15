using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {
	
	private string Name;
	public Character Character;
	public int Drunkenness;
	public string Request;
	public string Message;
	public bool RequestMatch;
	public UiController Ui;

	void Start () {
		this.Name = this.gameObject.name;
		this.Character = new Character (this.Name);
		Ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UiController>();
		Invoke ("GenerateRequest", 1);
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
		this.RequestMatch = false;
		// Check if Ingredients from DrinkController match Ingredients of requested Drink
		int rate = this.rateMix(Mix);
		Debug.Log ("Drink Rating: " + rate);
		if (this.RequestMatch) {
			Ui.ReceiveMoney (10);
			Ui.ReceiveChat(this.Name + ": Thank you, sir! :)\n");
			GenerateRequest ();
			return true;
		} else {
			Ui.ReceiveChat(this.Name + ": That was not what I've ordered! :(\n");
			return false;
		}
	}

	/*
	 * GenerateRequest(): Determines what the client wants to drink
	 */
	void GenerateRequest() {
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		this.Request =  drinkList[Random.Range(0, drinkList.Length)];
		Ui.ReceiveChat (this.Name + ": I would like to have a " + this.Request + "\n");
	}

	/*
	 * Rate Mix: Check ingredients and amount
	 * 
	 * Maximum amount of stars also depends also on complexity of drink (number of total ingredients)
	 * Basic ingredients (Cola, Beer...) never can be exact in amount. In this way thay can't contribute
	 * to the rating. Either they are or they aren't in the drink.
	 * 
	 * @return rate: 0 to 5
	 */ 
	private int rateMix(Dictionary<string, decimal> Mix) {
		int rate = 0;
		// Generate ingredient list from request by Drink()
		Drink targetDrink = new Drink(this.Request);

		// If list of ingredients missmatches
		if (Mix.Count != targetDrink.Ingredients.Count) {
			this.RequestMatch = false;
			return 0;
		}
		
		// Iterate over targetDrink
		foreach(var item in targetDrink.Ingredients) {
			decimal amount;

			// If ingredient is in Shaker
			if (Mix.TryGetValue (item.Key, out amount)) {
				this.RequestMatch = true;
				// Rate up if amount is exact
				if (amount == item.Value)
					rate++;
			} else {
				this.RequestMatch = false;
				break;
			}
		}
		return rate;
	}

	void AssessSatisfaction() {
		
	}

	void SmallTalk() {
		Debug.Log ("Do you want something from me?");
	}
}
