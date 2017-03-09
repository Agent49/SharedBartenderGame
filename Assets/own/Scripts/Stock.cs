using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Stock {

	// Define the amount and price of single ingredients a Gameobject may contains
	private static Dictionary<string, Ingredient> stockList = new Dictionary<string, Ingredient> () {
		{ "Beer", new Ingredient(500.0m, 0.6m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) }
	};

	private static string[] stockListKeys = stockList.Keys.ToArray ();

	public static Ingredient GetIngredient(string name) {
		return stockList [name];
	}

	public static bool IsStock(string name) {
		return stockList.ContainsKey (name);
	}
}
