using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : Container {

	private float timeStep = 0.5f;
	private float initialTime;

	// Use this for initialization
	void Start () {
		Initialize ();
		Debug.Log (Name);
		Debug.Log (MaxVol);
		Debug.Log (Volume);
		Debug.Log (liquidColor);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 90) {
			if (Input.GetMouseButtonDown (2))
				FlowOut ();
			else
				SipOut ();
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

		// Initialize Particle System
		InitializeParticleSystem();
	}

	public override void FlowOut() {
		Debug.Log ("FlowOut()");

		Particles.Play ();
	}

	public void SipOut() {
		if (initialTime == 0)
			initialTime = Time.time;
		
		if((Time.time - initialTime) >= timeStep) {
//			Debug.Log ("Sip");
			initialTime = Time.time;
		}

//		Debug.Log ("SipOut()");

		Particles.Play ();
	}
}
