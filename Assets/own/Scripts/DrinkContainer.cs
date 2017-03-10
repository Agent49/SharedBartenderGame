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

	public decimal fillIn(string ingredientName, decimal volume) {
		decimal tmp;
		if (DrinkIngredients.TryGetValue (ingredientName, out tmp))
			DrinkIngredients [ingredientName] += volume;
		else
			DrinkIngredients.Add (ingredientName, volume);
		
		Volume += volume;
		return volume;
	}

	public decimal fillUp(string ingredientName) {
		return 0.0m;
	}
}
