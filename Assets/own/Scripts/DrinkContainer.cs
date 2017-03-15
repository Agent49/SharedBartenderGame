using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkContainer : Container {
	
	public Dictionary<string, decimal> Ingredients;
	public Dictionary<string, int> Sugar;

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	protected override void Initialize() {
		// Derive Ingredient from gameObject name
		Name = rgx.Split(transform.name)[0];
		// Assign maxVolume
		MaxVol = Stock.GetDrinkContainer(Name);
		Volume = 0.0m;
		// Remember where object was initialized to respawn it
		spawnPosition = transform.position;

		Ingredients = new Dictionary<string, decimal> ();;
		Sugar = new Dictionary<string, int> ();

		foreach(Transform child in transform)
			child.gameObject.SetActive (false);
	}

	/*
	 * Add a sip of 1cl to the DrinkIngredients
	 */
	public decimal fillIn(string ingredientName, decimal volume) {
		
		if (Volume >= MaxVol)
			return 0.0m;

		decimal tmp;

		if (Ingredients.TryGetValue (ingredientName, out tmp))
			Ingredients [ingredientName] += volume;
		else
			Ingredients.Add (ingredientName, volume);
		
		Volume += volume;
		debugContainer ();
		return volume;
	}

	/*
	 * Fill DrinkContainer up to it's maximum volume
	 */
	public decimal fillUp(string ingredientName) {
		
		if (Volume >= MaxVol)
			return 0.0m;
		
		decimal tmp;
		decimal volume = MaxVol - Volume;

		if (Ingredients.TryGetValue (ingredientName, out tmp))
			Ingredients [ingredientName] += volume;
		else
			Ingredients.Add (ingredientName, volume);

		Volume += volume;
		debugContainer ();
		return volume;
	}

	public int GiveMeSugarBaby(string sugarName) {
		int sugarNum = 0;

		if (Sugar.TryGetValue (sugarName, out sugarNum))
			Sugar [sugarName] += 1;
		else
			Sugar.Add (sugarName, 1);
		
		debugContainer ();
		return sugarNum;
	}

	public void debugContainer() {
		string debug = "Volume: " + Volume + "\n";
		foreach(KeyValuePair<string, decimal> entry in Ingredients) {
			debug += entry.Key + " : " + entry.Value + "\n";
		}
		foreach(KeyValuePair<string, int> entry in Sugar) {
			debug += entry.Key + " : " + entry.Value + "\n";
		}
		GameMaster.DebugOut (debug);
	}
}
