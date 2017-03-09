using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkController : MonoBehaviour {

	private string name;
	private bool isStock;
	private decimal price;

	public Dictionary<string, decimal> DrinkIngredients = new Dictionary<string, decimal>();

	// Use this for initialization
	void Start () {
		// Try to identify transform name with ingredient name
		string[] splitStr = transform.name.Split ('_');
		name = splitStr [0];
		// Check if gameObject is a stock listed ingredient
		isStock = Stock.IsStock (transform.name);
		// Initialize what ingredient gameObject contains, amount and price
		if(isStock) {
			DrinkIngredients.Add (name, Stock.GetIngredientAmount(name));
			price = Stock.GetIngredientPrice (name);
		} else {
			price = 0m;	
		}
		Debug.Log ("Amount of Ingredient: " + DrinkIngredients [name]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Adds ingredients to Equipment objects
	 */
	private void AddIngredient(Transform Ingredient) {
//		decimal tmp;
//		// Add a shot
//		if (this.DrinkIngredients.TryGetValue (Ingredient.name, out tmp))
//			this.DrinkIngredients [Ingredient.name] += 20;
//		else
//			this.DrinkIngredients.Add (Ingredient.name, 20);
//
//		Debug.Log ("In Shaker:" + this.DrinkIngredients [Ingredient.name]);
	}

	/*
	 * Empty Equipment
	 */
	public void EmptyEquipment() {
//		this.DrinkIngredients.Clear();
//		Debug.Log (this.DrinkIngredients);
	}
}
