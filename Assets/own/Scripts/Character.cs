using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public string Name;
	public float Durability;			// Factor to apply on promille level
	public string[] FavoriteDrinks;		// Only these kind of Drinks the client always orders
	public string[] DrinkSelection;		// Just specify if there are limitations like non-alcoholics
	public Dictionary<int, string[]> Talk;

	private static Dictionary<string, Dictionary<string, string[]>> TalkList = new Dictionary<string, Dictionary<string, string[]>>() {
		// Straight edge
		{
			"Bastian", new Dictionary<string, string[]>() {
				{"hello", new string[] {"Ähhh... Howdy Partner?"}},
				{"bye", new string[] {"Ich... äh ich geh wohl lieber langsam los... ist schon fast dunkel draußen."}},
				{"sober", new string[] {"Also ich bin sowas von straight!"}}
			}
		},
		// Alcoholic
		{
			"Klaus", new Dictionary<string, string[]>() {
				{"hello", new string[] {"Guten Morgen, Alter!"}},
				{"complaint", new string[] {"Hast"}},
				{"sober", new string[] {"Was für'n beschissener Tag!"}},
				{"tipsy", new string[] {"Jetzt geht's mir schon viel besser."}},
				{"drunken", new string[] {"Hey Mann, du bist mein bester Freund. Ich liebe dich Alter."}}
			}
		}
	};


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
//			this.Talk = new Dictionary<int, string[]> {}
			break;
		case "Klaus":
			this.FavoriteDrinks = new string[] {"Beer"};
			break;
		}
	}
}
