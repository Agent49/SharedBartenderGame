using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour {

	public Drink RequestedDrink;
	public Drink ReceivedDrink;
	public bool Match;
	public int Rate;
	public float OrderTime;
	public int old_Tip;
	public decimal Tip = 0m;
	public string FeedBack;

	public int State;

	/*
	 * Constructed everytime a client makes a request
	 */
	public Request() {
		// 1.) Get a drinklist
		string[] drinkList = Drink.GetDrinkList ();
		// 2.) Choose one drink randomly
		RequestedDrink = new Drink(drinkList[Random.Range(0, drinkList.Length)]);
		// 3.) Time to evaluate duration
		OrderTime = Time.time;
		// 4.) Set first requestState "0" which is: not yet processed
		State = 0;

		Match = false;
	}

	public bool Receive(Collider other) {
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();

		if (drinkContainer == null) {
			// Object not of type DrinkContainer
			State = 1;
			FeedBack = "no_drink_container";
			return false;
		}

		if((drinkContainer.Ingredients == null) || (drinkContainer.Ingredients.Count == 0)) {
			// Nothing in DrinkContainer
			State = 2;
			FeedBack = "empty_drink_container";
			return false;
		}

		ReceivedDrink = new Drink (drinkContainer);
		Debug.Log(ReceivedDrink.ToString ());

		return rateMix ();
	}

	public int RequestState {
		get { return State; }
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
	private bool rateMix() {
		Rate = 0;

		// Anything in DrinkContainer but not the requested Drink
		State = 3;
		FeedBack = "no_drink_match";

		// 1) If list of ingredients missmatches
		if (ReceivedDrink.Ingredients.Count != RequestedDrink.Ingredients.Count)
			return false;


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
				State = 3;
				return false;
			}
		}

		// Approach: The Drink is takeable
		State = 4;
		Match = true;
		FeedBack = "drink_okay";
			
		// 3) Iterate over RequestedDrink Sugar
		int numOfSugars;
		foreach (KeyValuePair<string, int> entry in RequestedDrink.Sugar) {
			if (ReceivedDrink.Sugar.TryGetValue (entry.Key, out numOfSugars))
				Rate++;
		}

		if (Rate > 2) {
			State = 5;
			FeedBack = "great_drink";
		}

		return true;
	}


	/*
	 * CalculateTip: The tip depends on
	 * Character (generousness), Random, Duration, 
	 * complexity of Drink, Price of Drink, Drink Quality
	 * 
	 * Know your Clients! Know how to mix good and fast!
	 */
	public bool CalculateTip() {
		Tip = 0.0m;
		float kRandom = Random.Range (0.0f, 1.0f);

		if (kRandom < 0.5f)
			return false;

		Tip = (decimal)System.Math.Round((double)RequestedDrink.Price * 0.1 * Rate);

		if (Tip > 0)
			return true;
		else
			return false;
	}
}
