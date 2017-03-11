using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkContainer : Container {

	public Dictionary<string, decimal> DrinkIngredients = new Dictionary<string, decimal> ();

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x"))
			Debug.Log ("X pressed.");
	}

	protected override void Initialize() {
		// Derive Ingredient from gameObject name
		Name = transform.name.Split ('_')[0];	
		// Assign maxVolume
		MaxVol = Stock.GetDrinkContainer(Name);
		Volume = 0.0m;
	}

	public override void FlowOut() {
		
	}

	/*
	 * Add a sip of 1cl to the DrinkIngredients
	 */
	public decimal fillIn(string ingredientName, decimal volume) {
		
		if (Volume >= MaxVol)
			return 0.0m;

		decimal tmp;

		if (DrinkIngredients.TryGetValue (ingredientName, out tmp))
			DrinkIngredients [ingredientName] += volume;
		else
			DrinkIngredients.Add (ingredientName, volume);
		
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

		if (DrinkIngredients.TryGetValue (ingredientName, out tmp))
			DrinkIngredients [ingredientName] += volume;
		else
			DrinkIngredients.Add (ingredientName, volume);

		Volume += volume;
		debugContainer ();
		return volume;
	}

	private void debugContainer() {
		string debug = "Volume: " + Volume + "\n";
		foreach(KeyValuePair<string, decimal> entry in DrinkIngredients) {
			debug += entry.Key + " : " + entry.Value + "\n";
		}
		GameMaster.DebugOut (debug);
	}
}
