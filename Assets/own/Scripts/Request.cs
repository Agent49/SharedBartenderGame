using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour {

	public Drink Drink;
	public bool Match;
	public int Rate;
	public float InitialTime;
	public int Tip;

	public static float K;

	public Request() {
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		this.Drink = new Drink(drinkList[Random.Range(0, drinkList.Length)]);
		// 3.) Time to evaluate duration
		InitialTime = Time.time;
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

	/*
	 * CalculateTip: The tip depends on
	 * Character (generousness), Random, Duration, 
	 * complexity of Drink, Price of Drink, Drink Quality
	 * 
	 * Know your Clients! Know how to mix good and fast!
	 */
	public int CalculateTip(float generousness) {
		this.Tip = 0;
		int complexity = Drink.Ingredients.Count;
		// Is the Client willing to give a tip?
		float kRandom = Random.Range (0.0f, 1.0f) * generousness;
		// How much time has passed?
		float duration = Time.time - InitialTime;
		// Maximum time allowed depends on number of ingredients
		float maxTime = 10f + Mathf.Pow ((float)complexity, 2.0f);

		if (true || (kRandom > 0.5f) && (duration < maxTime)) {
			this.Tip = (int)Mathf.Round ((float)Drink.Price * Rate * 0.3f);
		}

		return this.Tip;
	}
}
