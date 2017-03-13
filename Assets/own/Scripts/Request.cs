using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour {

	public Drink RequestedDrink;
	public Drink ReceivedDrink;
	public bool Match;
	public int Rate;
	public float InitialTime;
	public int Tip;

	private int requestState;

	/*
	 * Constructed everytime a client makes a request
	 */
	public Request() {
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		RequestedDrink = new Drink(drinkList[Random.Range(0, drinkList.Length)]);
		// 3.) Time to evaluate duration
		InitialTime = Time.time;
		// 4.) Set first requestState "0" which is: not yet processed
		requestState = 0;
	}

	public bool Receive(Collider other) {
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();

		if (drinkContainer == null) {
			// Object not of type DrinkContainer
			requestState = 1;
			return false;
		}

		if((drinkContainer.Ingredients == null) || (drinkContainer.Ingredients.Count == 0)) {
			// Nothing in DrinkContainer
			requestState = 2;
			return false;
		}

		ReceivedDrink = new Drink (drinkContainer);
		Debug.Log(ReceivedDrink.ToString ());

		return rateMix ();
	}

	public int RequestState {
		get { return requestState; }
	}

	private bool rateMix() {
		Rate = 0;

		// Anything in DrinkContainer but not the requested Drink
		requestState = 3;

		// 1) If list of ingredients missmatches
		if (ReceivedDrink.Ingredients.Count != RequestedDrink.Ingredients.Count)
			return false;

		// Approach: The Drink is takeable
		requestState = 4;

		// 2) Iterate over RequestedDrink Ingredients
		// 2.1) Deny if Drink does not contain one ingredient in receipe
		// 2.2) Upvote if Volume matches
		// Hint: For better balance Overall volume won't be checked but implicitly by this routine if player filled-up
		decimal volume;
		foreach(KeyValuePair<string, decimal> entry in RequestedDrink.Ingredients) {
			// If Ingredient is in DrinkContainer
			if(ReceivedDrink.Ingredients.TryGetValue(entry.Key, out volume)) {
				if (volume == entry.Value)
					Rate++;
			} else {
				requestState = 3;
				return false;
			}
		}
			
		// 3) Iterate over RequestedDrink Sugar
		int numOfSugars;
		foreach (KeyValuePair<string, int> entry in RequestedDrink.Sugar) {
			if (ReceivedDrink.Sugar.TryGetValue (entry.Key, out numOfSugars))
				Rate++;
		}

		if (Rate > 2)
			requestState = 5;

		return true;
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
	public int old_RateMix(Dictionary<string, decimal> Mix) {
		Rate = 0;

		// If list of ingredients missmatches
		if (Mix.Count != RequestedDrink.Ingredients.Count) {
			Match = false;
			return 0;
		}

		// Iterate over targetDrink
		foreach(var item in RequestedDrink.Ingredients) {
			decimal amount;
			// If ingredient is in Shaker
			if (Mix.TryGetValue (item.Key, out amount)) {
				Match = true;
				// Rate up if amount is exact
				if (amount == item.Value)
					Rate++;
			} else {
				Match = false;
				break;
			}
		}
		return Rate;
	}

	/*
	 * CalculateTip: The tip depends on
	 * Character (generousness), Random, Duration, 
	 * complexity of Drink, Price of Drink, Drink Quality
	 * 
	 * Know your Clients! Know how to mix good and fast!
	 */
	public int CalculateTip(float generousness) {
		Tip = 0;
		int complexity = RequestedDrink.Ingredients.Count;
		// Is the Client willing to give a tip?
		float kRandom = Random.Range (0.0f, 1.0f) * generousness;
		// How much time has passed?
		float duration = Time.time - InitialTime;
		// Maximum time allowed depends on number of ingredients
		float maxTime = 10f + Mathf.Pow ((float)complexity, 2.0f);

		if (true || (kRandom > 0.5f) && (duration < maxTime)) {
			Tip = (int)Mathf.Round ((float)RequestedDrink.Price * Rate * 0.3f);
		}

		Debug.Log ("Tip: " + Tip);
		return Tip;
	}
}
