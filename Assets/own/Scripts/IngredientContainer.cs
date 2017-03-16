using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientContainer : Container {

	private float timeStep = 0.4f;
	private float initialTime;
	private decimal sip = 10.0m;

	private MeshRenderer closedBottle;

	// Use this for initialization
	void Start () {
		interactibleItem = transform.GetComponent<NewtonVR.NVRInteractableItem> ();
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 90 && (Volume > 0)) {
			FlowOut ();
		} else {
			initialTime = 0.0f;
			Particles.Stop ();
		}

		if ((interactibleItem.IsAttached))
			closedBottle.enabled = false;

		if(GameMaster.RightNVRControls.Inputs [NewtonVR.NVRButtons.Trigger].IsPressed)
			Debug.Log("RightNVRControls is pressed");
	}

	protected override void Initialize() {
		// Derive Ingredient from gameObject name
		Name = rgx.Split(transform.name)[0];
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

		// Initialize closed Mesh
		closedBottle = gameObject.transform.GetChild (1).GetComponent<MeshRenderer>();
		if(closedBottle != null)
			closedBottle.enabled = true;
	}

	public void FlowOut() {
		bool isFillUp = (
			Input.GetMouseButton (2) ||
			(GameMaster.RightNVRControls.Inputs [NewtonVR.NVRButtons.Trigger].IsPressed) ||
			(GameMaster.LeftNVRControls.Inputs [NewtonVR.NVRButtons.Trigger].IsPressed)
		) && ((Time.time - initialTime) >= (timeStep));

		if (Physics.Raycast(particleSource.transform.position, Vector3.down, out hit, range)) {
			DrinkContainer drinkContainer = hit.collider.gameObject.GetComponent<DrinkContainer> ();

			// If hit object is a DrinkContainer (has sript attached)
			if ((drinkContainer != null)) {

				if (initialTime == 0)
					initialTime = Time.time;

				if (isFillUp) {
					initialTime = Time.time;
					Volume -= drinkContainer.fillUp (Name);
				} else if((Time.time - initialTime) >= timeStep) {
					GameMaster.AudioSip.Play ();
					initialTime = Time.time;
					Volume -= drinkContainer.fillIn (Name, sip);
				}
			}
		}
		Particles.Play ();
	}
}
