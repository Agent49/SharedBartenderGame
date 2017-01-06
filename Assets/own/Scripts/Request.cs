using UnityEngine;
using System.Collections;

public class Request : MonoBehaviour {

	bool Match;
	int Rate;
	float StartTime;

	public Request() {
		this.StartTime = Time.time;
		Debug.Log (this.StartTime);
	}

	private void chooseDrink() {
		// TODO: Perfomance Issue!
		string[] drinkList = Drink.GetDrinkList ();
	}
}
