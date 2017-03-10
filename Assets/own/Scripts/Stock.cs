using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Stock {

	// Define the amount and price of single ingredients a Gameobject may contains
	private static Dictionary<string, Ingredient> stockIngredients = new Dictionary<string, Ingredient> () {
		{ "Beer", new Ingredient(500.0m, 0.6m, new Color(.99f, .89f, .22f, .75f)) },
		{ "Whisky", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) }
	};

	private static Dictionary<string, decimal> stockDrinkContainer = new Dictionary<string, decimal>() {
		{"GlassBeer", 500.0m }
	};

	private static string[] stockListKeys = stockIngredients.Keys.ToArray ();

	public static Ingredient GetIngredient(string name) {
		return stockIngredients [name];
	}

	public static bool IsStock(string name) {
		return stockIngredients.ContainsKey (name);
	}
}
