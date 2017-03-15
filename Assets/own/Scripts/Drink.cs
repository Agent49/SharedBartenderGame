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
		{"Bier", new Dictionary<string, decimal> {{"Beer", 500.0m}}},
		{"doppelten Gin", new Dictionary<string, decimal> {{"Gin", 40.0m}}},
		{"doppelten Rum", new Dictionary<string, decimal> {{"Rum", 40.0m}}},
		{"doppelten Whisky", new Dictionary<string, decimal> {{"Whisky", 40.0m}}},
		{"doppelten Wodka", new Dictionary<string, decimal> {{"Wodka", 40.0m}}},
		{"doppelten Tequila", new Dictionary<string, decimal> {{"Tequila", 40.0m}}},
		{"Cola", new Dictionary<string, decimal> {{"Cola", 40.0m}}},
		{"Orangensaft", new Dictionary<string, decimal> {{"Ojuice", 300.0m}}},
		{"Rotwein", new Dictionary<string, decimal> {{"RedWine", 250.0m}}},
		{"Weisswein", new Dictionary<string, decimal> {{"WhiteWine", 250.0m}}},
		{"Sekt", new Dictionary<string, decimal> {{"SparklingWine", 200.0m}}},
		{"Diesel", new Dictionary<string, decimal> {{"Beer", 250.0m}, {"Cola", 250.0m}}},
		{"Cuba Libre", new Dictionary<string, decimal> {{"Rum", 60.0m},{"Cola", 290.0m}}},
		{"Gin Tonic", new Dictionary<string, decimal> {{"Gin", 60.0m}, {"Tonic", 290.0m}}},
		{"Tequila Sunrise", new Dictionary<string, decimal> {{"Tequila", 60.0m}, {"Cjuice", 10.0m},{"Grenadine", 10.0m},{"Ojuice", 270.0m}}},
		{"Tequila Sour", new Dictionary<string, decimal> {{"Tequila", 60.0m}, {"Cjuice", 50.0m},{"Sirup", 10.0m},{"Water", 280.0m}}},
		{"White Lady", new Dictionary<string, decimal> {{"Gin", 60.0m}, {"SparklingWine", 340.0m}}},
		{"Gin and Sin", new Dictionary<string, decimal> {{"Tequila", 80.0m}, {"Grenadine", 20.0m},{"Cjuice", 60.0m},{"Ojuice", 240.0m}}},
		{"Daiquiri", new Dictionary<string, decimal> {{"Rum", 80.0m}, {"Sugar", 60.0m},{"Ljuice", 260.0m}}},
		{"Mojito", new Dictionary<string, decimal> {{"Rum", 60.0m}, {"Sugar", 40.0m},{"Ljuice", 400.0m},{"Water", 160.0m}}},
		{"Gin Fizz", new Dictionary<string, decimal> {{"Gin", 50.0m}, {"Cjuice", 30.0m}, {"Sirup", 20.0m}, {"Water", 100.0m}}},
		{"Whisky Sour", new Dictionary<string, decimal> {{"Whisky", 50.0m}, {"Cjuice", 30.0m}, {"Sirup", 20.0m}, {"Water", 100.0m}}}
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
		case "Bier":
			Price = 3;
			Sugar = new Dictionary<string, int> ();
			break;
		case "doppelten Gin":
			Price = 3.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "doppelten Rum":
			Price = 3.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "doppelten Whisky":
			Price = 3.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "doppelten Wodka":
			Price = 3.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "doppelten Tequila":
			Price = 3.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Orangensaft":
			Price = 2m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Cola":
			Price = 2;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Rotwein":
			Price = 5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Weisswein":
			Price = 4m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Sekt":
			Price = 4m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Diesel":
			Price = 2.5m;
			Sugar = new Dictionary<string, int> ();
			break;
		case "Cuba Libre":
			Price = 6;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 }, { "Lime", 1 }};
			break;
		case "Gin Tonic":
			Price = 8;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Tequila Sunrise":
			Price = 7;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Tequila Sour":
			Price = 6;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "White Lady":
			Price = 6;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } , { "Citrus", 1 }};
			break;
		case "Gin and Sin":
			Price = 7;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Daiquiri":
			Price = 6;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Mojito":
			Price = 8;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Gin Fizz":
			Price = 7;
			Sugar = new Dictionary<string, int> () { { "Ice", 1 } };
			break;
		case "Whisky Sour":
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
