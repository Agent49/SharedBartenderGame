using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * Class: Drink
 * 
 * This class is a container for the ingredients of a requested drink.
 * It allocates all the ingredients automatically
 * by calling the constructor with the drink name.
 * 
 * @constructorParams: string "Drink"
 */

public class Drink : MonoBehaviour {
	
	public string Name;
	public decimal Price;
	public decimal Volume;
	public Dictionary<string, decimal> Ingredients;
	public Dictionary<string, int> Sugar;

	// Basic ingredients like "Cola" or "Beer" always have value >=100
	private static Dictionary<string, Dictionary<string, decimal>> drinkList = new Dictionary<string, Dictionary<string, decimal>>() {
		{"Beer", new Dictionary<string, decimal> {{"Beer", 500.0m}}},
		{"Cola", new Dictionary<string, decimal> {{"Cola", 350.0m}}},
		{"Diesel", new Dictionary<string, decimal> {{"Beer", 250.0m}, {"Cola", 250.0m}}},
		{"Cuba Libre", new Dictionary<string, decimal> {{"Cola", 340.0m}, {"Rum", 60.0m}}}
	};

	// How much % alcohol does an ingredient contain?
//	private static Dictionary<string, int> Ingredient = new Dictionary<string, int> {
//		{"Cola", 0}, {"Orange", 0}, {"Pineapple", 0}, {"Grenadine", 0}, {"Beer", 5}, {"Lemon", 0}, {"Schnapps", 40}
//	};


	public Drink(DrinkContainer drinkContainer) {
		Ingredients = drinkContainer.Ingredients;
		Sugar = drinkContainer.Sugar;
		DetermineVolume ();
	}

	/*
	 * Contruct drink with all its ingredients by name
	 */
	public Drink(string name) {
		Name = name;
		SetDrinkByName ();
		DetermineVolume ();
	}


	/*
	 * @return: array of key which are names of drinks
	 */
	public static string[] GetDrinkList() {
		return drinkList.Keys.ToArray ();
	}

	/*
	 * Set properties of a drink like ingredients and price
	 */
	// TODO: Read everything from xml... better data structure
	private void SetDrinkByName() {
		Ingredients = drinkList [Name];
		switch(Name) {
		case "Beer":
			Price = 3;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Cola":
			Price = 2;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Diesel":
			Price = 2.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Cuba Libre":
			Price = 6;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		}
	}

	private void DetermineVolume() {
		Volume = 0m;
		foreach(KeyValuePair<string, decimal> entry in Ingredients) {
			Volume += entry.Value;
		}
	}

	public string ToString() {
		string objectString = "DRINK";
		if (Name != null)
			objectString += "\nName: " + Name;
		if(Price != null)
			objectString += "\nPrice: " + Price;
		if(Volume != null)
			objectString += "\nVolume: " + Volume;

		if (Ingredients != null)
			foreach (KeyValuePair<string, decimal> entry in Ingredients)
				objectString += "\n" + entry.Key + ": " + entry.Value;

		if (Sugar != null)
			foreach (KeyValuePair<string, decimal> entry in Ingredients)
				objectString += "\n" +  entry.Key + ": " + entry.Value;

		return objectString;
	}
}
