using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : Container {

	public string Name;
	public decimal Volume;

	// Use this for initialization
	void Start () {
		Initialize ();
		Debug.Log (Name);
		Debug.Log (maxVol);
		Debug.Log (Volume);
		Debug.Log (liquidColor);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 90) {
			if (Input.GetMouseButtonDown (2))
				SipOut ();
			else
				FlowOut ();
		}
	}

	protected override void Initialize() {
		// Derive Ingredient from gameObject name
		Name = transform.name.Split ('_')[0];
		// Get data from stock
		Ingredient ingredient = Stock.GetIngredient(Name);
		// Assign initial and present volume
		maxVol = Volume = ingredient.Volume;
		// Assign liquid color
		liquidColor = ingredient.lColor;

		// Initialize Particle System
		InitializeParticleSystem();
	}

	public override void FlowOut() {
		Debug.Log ("FlowOut()");
	}

	public void SipOut() {
		Debug.Log ("SipOut()");
	}
}
