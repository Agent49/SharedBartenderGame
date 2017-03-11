using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

	public bool OnTriggerEnter(Collider other){
		IngredientContainer ingredientContainer = other.GetComponent<IngredientContainer> ();
		if (ingredientContainer != null) {
			ingredientContainer.ReSpawn ();
			return true;
		}
			
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();
		if(drinkContainer != null) {
			drinkContainer.ReSpawn ();
			return true;			
		}

		return false;
	}
}
