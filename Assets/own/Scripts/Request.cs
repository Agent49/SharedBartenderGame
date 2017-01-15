using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour {

	public Drink Drink;
	public bool Match;
	public int Rate;
	public float Duration;
	public int Tip;

	public static float K;

	public Request() {
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		this.Drink = new Drink(drinkList[Random.Range(0, drinkList.Length)]);
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
	public int RateMix(Dictionary<string, decimal> Mix) {
		this.Rate = 0;

		// If list of ingredients missmatches
		if (Mix.Count != this.Drink.Ingredients.Count) {
			this.Match = false;
			return 0;
		}

		// Iterate over targetDrink
		foreach(var item in this.Drink.Ingredients) {
			decimal amount;
			// If ingredient is in Shaker
			if (Mix.TryGetValue (item.Key, out amount)) {
				this.Match = true;
				// Rate up if amount is exact
				if (amount == item.Value)
					this.Rate++;
			} else {
				this.Match = false;
				break;
			}
		}
		return this.Rate;
	}

	public int CalculateTip() {
		this.Tip = 0;
//				Debug.Log ("Generousness: " + this.Character.Generousness [0]);
//				Debug.Log ("Price: " + this.TargetDrink.Price);
//				Debug.Log ("Rate: " + this.Rate);
//				Debug.Log ("Duration: " + this.Rate);
		return this.Tip;
	}
}
