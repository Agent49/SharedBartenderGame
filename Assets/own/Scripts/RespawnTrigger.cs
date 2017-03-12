using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

	public bool OnTriggerEnter(Collider other){
		IngredientContainer ingredientContainer = other.GetComponent<IngredientContainer> ();
		if (ingredientContainer != null) {
			ingredientContainer.ReSpawn (5f);
			return true;
		}
			
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();
		if(drinkContainer != null) {
			drinkContainer.ReSpawn (5f);
			return true;			
		}

		Sugar sugar = other.GetComponent<Sugar> ();
		if(sugar != null) {
			sugar.ReSpawn (5f);
		}

		return false;
	}
}
