using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Stock {

	// Define the amount and price of single ingredients a Gameobject may contains
	private static Dictionary<string, Ingredient> stockIngredients = new Dictionary<string, Ingredient> () {
		{ "Beer", new Ingredient(500.0m, 0.6m, new Color(.99f, .89f, .22f, .75f)) },
		{ "Cola", new Ingredient(1000.0m, 1.0m, new Color(0.56f, 0.11f, 0.11f, 0.75f)) },
		{ "Rum", new Ingredient(700.0m, 12.0m, new Color(0.47f, 0.25f, 0.15f, 0.75f)) },
		{ "Whisky", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "Gin", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "Wodka", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "RedWine", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "WhiteWine", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "SparklingWine", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "Ojuice", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "Grenadine", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) },
		{ "Tequila", new Ingredient(700.0m, 12.0m, new Color(1.0f, 0.0f, 0.0f, 1.0f)) }
	};

	private static Dictionary<string, decimal> stockDrinkContainer = new Dictionary<string, decimal>() {
		{"GlassBeer", 500.0m },
		{"GlassCocktail", 400.0m },
		{"GlassLongdrink", 350.0m },
		{"GlassSoftdrink", 300.0m },
		{"GlassWine", 250.0m },
		{"GlassSparklingWine", 200.0m },
		{"GlassDoubleShot", 40.0m },
		{"GlassDouble", 20.0m }
	};

	private static string[] stockIngredientsKeys = stockIngredients.Keys.ToArray ();
	private static string[] stockDrinkContainerKeys = stockIngredients.Keys.ToArray ();

	public static Ingredient GetIngredient(string name) {
		return stockIngredients [name];
	}

	public static decimal GetDrinkContainer(string name) {
		return stockDrinkContainer [name];
	}

	public static bool IsStock(string name) {
		return stockIngredients.ContainsKey (name);
	}
}
