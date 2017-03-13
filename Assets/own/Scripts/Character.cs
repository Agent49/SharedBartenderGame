using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public string Name;
	public float Durability;			// Factor to apply on promille level
	public float[] Generousness;		// Factor to apply on tip
	public string[] FavoriteDrinks;		// Only these kind of Drinks the client always orders
	public string[] DrinkSelection;		// Just specify if there are limitations like non-alcoholics
	public Dictionary<string, string[]> Talk;

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
				{"drunken", new string[] {"Hey Mann, du bist mein bester Freund. Ich liebe dich!"}}
			}
		},
		{
			"Egon", new Dictionary<string, string[]>() {
				{"hello", new string[] {"Guten Morgen, Alter!"}},
				{"complaint", new string[] {"Hast"}},
				{"sober", new string[] {"Was für'n beschissener Tag!"}},
				{"tipsy", new string[] {"Jetzt geht's mir schon viel besser."}},
				{"drunken", new string[] {"Hey Mann, du bist mein bester Freund. Ich liebe dich!"}},
				{"order", new string[] {"Ich hätte gern ein "}},
				{"no_drink_container", new string[] {"Hä? Was soll ich denn damit?"}},
				{"empty_drink_container", new string[] {"Warum denn so geizig?"}},
				{"no_drink_match", new string[] {"Ich weiß ja nicht was das sein soll, aber das ist sicher nicht was ich bestellt habe."}},
				{"drink_okay", new string[] {"Danke."}},
				{"great_drink", new string[] {"Wow! Wo hast du gelernt solch fette Drinks zu mischen?"}}
			}
		}
	};


	/*
	 * Character: Call constructor to assign specific character properties
	 */
	public Character(string name) {
		Name = name;
		SetProperties ();
	}

	public string Say(string key) {
		string[] messageOptions = Talk [key];
		return messageOptions [Random.Range (0, messageOptions.Length)];
	}

	private void SetProperties() {
		switch(Name) {
		// Does not drink alcohol at all, is a bit Hipster
		case "Bastian":
			Durability = 1.0f;
			Generousness = new float[] { 0.0f, 0.1f, 0.2f };
			FavoriteDrinks = new string[] { "Cola" };
			Talk = TalkList [Name];
			break;
		case "Klaus":
			Durability = 3.5f;
			Generousness = new float[] { 0.8f, 0.85f, 1.0f };
			FavoriteDrinks = new string[] { "Beer" };
			Talk = TalkList [Name];
			break;
		case "Egon":
			Durability = 3.5f;
			Generousness = new float[] { 0.8f, 0.85f, 1.0f };
			FavoriteDrinks = new string[] { "Beer" };
			Talk = TalkList [Name];
			break;
		}
	}
}
