using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

	public bool OnTriggerEnter(Collider other){
		float spawnTime;

		if (gameObject.name.Equals ("Tray"))
			spawnTime = transform.parent.gameObject.GetComponent<Client> ().GetDrink (other);
		else
			spawnTime = 5f;
			

		IngredientContainer ingredientContainer = other.GetComponent<IngredientContainer> ();
		if (ingredientContainer != null) {
			ingredientContainer.ReSpawn (spawnTime);
			return true;
		}
			
		DrinkContainer drinkContainer = other.GetComponent<DrinkContainer> ();
		if(drinkContainer != null) {
			drinkContainer.ReSpawn (spawnTime);
			return true;			
		}

		Sugar sugar = other.GetComponent<Sugar> ();
		if(sugar != null) {
			sugar.ReSpawn (spawnTime);
			return true;
		}

		return false;
	}
}
