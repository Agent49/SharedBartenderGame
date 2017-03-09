using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Stock {

	// Define the amount and price of single ingredients a Gameobject may contains
	private static Dictionary<string, decimal[]> stockList = new Dictionary<string, decimal[]> () {
		{ "Beer", new decimal[] { 500.0m, 0.6m } }
	};

	private static string[] stockListKeys = stockList.Keys.ToArray ();

	public static decimal GetIngredientAmount(string gameObjectName) {
		decimal[] amount;
		if (stockList.TryGetValue (gameObjectName, out amount))
			return amount[0];
		else
			return 0m;
	}

	public static decimal GetIngredientPrice(string gameObjectName) {
		decimal[] amount;
		if (stockList.TryGetValue (gameObjectName, out amount))
			return amount[1];
		else
			return 0m;		
	}

	public static bool IsStock(string gameObjectName) {
		string[] splitStr = gameObjectName.Split ('_');
		return stockList.ContainsKey (splitStr [0]);
	}
}
