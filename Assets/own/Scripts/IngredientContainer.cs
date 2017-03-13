using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : Container {

	private float timeStep = 0.4f;
	private float initialTime;
	private decimal sip = 10.0m;

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 90) {
			FlowOut ();
		} else {
			initialTime = 0.0f;
			Particles.Stop ();
		}
	}

	protected override void Initialize() {
		// Derive Ingredient from gameObject name
		Name = transform.name.Split ('_')[0];
		// Get data from stock
		Ingredient ingredient = Stock.GetIngredient(Name);
		// Assign initial and present volume
		MaxVol = Volume = ingredient.Volume;
		// Assign liquid color
		liquidColor = ingredient.lColor;

		// Reset time
		initialTime = 0.0f;

		// Remember where object was initialized to respawn it
		spawnPosition = transform.position;

		// Initialize Particle System
		InitializeParticleSystem();
	}

	public void FlowOut() {
		Debug.Log (particleSource.transform.position);
		if (Physics.Raycast(particleSource.transform.position, Vector3.down, out hit, range)) {
			DrinkContainer drinkContainer = hit.collider.gameObject.GetComponent<DrinkContainer> ();

			// If hit object is a DrinkContainer (has sript attached)
			if (drinkContainer != null) {

				if (initialTime == 0)
					initialTime = Time.time;

				if (Input.GetMouseButton (2) && ((Time.time - initialTime) >= (timeStep))) {
					initialTime = Time.time;
					drinkContainer.fillUp (Name);
				} else if((Time.time - initialTime) >= timeStep) {
					initialTime = Time.time;
					drinkContainer.fillIn (Name, sip);
				}
			}
		}
		Particles.Play ();
	}
}
