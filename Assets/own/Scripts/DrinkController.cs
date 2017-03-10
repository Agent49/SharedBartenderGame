using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkController : MonoBehaviour {

	private string name;
	private bool isStock;
	private decimal price;

	private Transform ParticleSource;
	private RaycastHit hit;

	public ParticleSystem Liquid;

	public Dictionary<string, decimal> DrinkIngredients = new Dictionary<string, decimal>();

	// Use this for initialization
	void Start () {
//		Debug.Log ("0000000000");
//		// Try to identify transform name with ingredient name
//		string[] splitStr = transform.name.Split ('_');
//		name = splitStr [0];
//		// Check if gameObject is a stock listed ingredient
//		isStock = Stock.IsStock ("Beer");
//		// Initialize what ingredient gameObject contains, amount and price
//		if(isStock) {
//			Ingredient ingredient = Stock.GetIngredient (name);
//			DrinkIngredients.Add (name, ingredient.Volume);
//		} 
//		Debug.Log ("Amount of Ingredient: " + DrinkIngredients ["Beer"]);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 90)
			drainOff ();
	}

	private void drainOff() {
//		if(Physics.Raycast(ParticleSource.position, Vector3.down))	
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
