using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour {

	private bool isTrigger = true;

	public bool OnTriggerEnter(Collider other){
		
		if (!isTrigger)
			return false;

		float spawnTime;

		if (gameObject.name.Equals ("Tray") && (other.GetComponent<DrinkContainer> () != null)) {
			spawnTime = transform.parent.gameObject.GetComponent<Client> ().GetDrink (other);
			isTrigger = false;
			StartCoroutine (DelayedEnableTrigger (spawnTime));
		} else {
			spawnTime = 5f;
		}

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

	IEnumerator DelayedEnableTrigger(float enableDelay) {
		yield return new WaitForSeconds (enableDelay);
		isTrigger = true;
	}

}
