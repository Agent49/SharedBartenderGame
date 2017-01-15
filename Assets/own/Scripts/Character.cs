using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public string Name;
	public float Durability;			// Factor to apply on promille level
	public string[] FavoriteDrinks;		// Only these kind of Drinks the client always orders
	public string[] DrinkSelection;		// Just specify if there are limitations like non-alcoholics


	/*
	 * Character: Call constructor to assign specific character properties
	 */
	public Character(string Name) {
		this.Name = Name;
		this.SetProperties ();
	}

	private void SetProperties() {
		switch(this.Name) {
		// Does not drink alcohol at all, is a bit Hipster
		case "Bastian":
			this.FavoriteDrinks = new string[] {"Cola"};
			break;
		case "Klaus":
			this.FavoriteDrinks = new string[] { "Beer", "Jägermeister" };
			break;
		}
	}
}
