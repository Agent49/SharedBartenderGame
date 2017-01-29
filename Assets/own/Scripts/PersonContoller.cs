using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PersonContoller : MonoBehaviour {

	private bool isPickedUpRight;
	private bool justDropped;
	private float range = 10f;
	private RaycastHit hit;
	public UiController Ui;
	public Transform Inventory;
	public Transform RightItem;
	private Transform RightHand;
	private Transform Ingredients;
	private Transform Equipment;
	private Transform Clients;

	// Use this for initialization
	void Start () {
		this.isPickedUpRight = false;
		this.RightHand = this.gameObject.transform.GetChild (0);
		// Load UiController in order to execute member functions
		Ui = GameObject.FindGameObjectWithTag("DebugUI").GetComponent<UiController>();
		Ingredients = GameObject.Find ("Ingredients").transform;
		Equipment = GameObject.Find ("Equipment").transform;
		Clients = GameObject.Find ("Clients").transform;
	}
	
	// Update is called once per frame
	void Update () {
		

		// Drop Inventory
		if (Input.GetButtonDown ("Fire1")) {
			this.DropItem ();
		}

		CheckForHit ();

		this.holdItem ();

		this.justDropped = false;

		if (this.isPickedUpRight) {
			this.holdItem ();
		}
	}

	/*
	 * Everytime when the Ray hits a collider it checks if the hit object
	 * is an object one can interact with
	 */
	void CheckForHit () {
		// Check if Ray hits an item
		if(Physics.Raycast(transform.position, transform.forward, out hit, range)) {
			// Check if item is interactable
			if(hit.transform.tag.Equals("Interaction")) {
				Ui.ActivateCrosshair();
				if (Input.GetButtonDown ("Fire1"))
					Interact ();
			} else {
				Ui.DeactivateCrosshair();
			}
		} else {
			// Change Crosshair to inactive
			Ui.DeactivateCrosshair();
		}
	}

	/*
	 * Depending on hit objects this controls the interaction between Barkeeper
	 * Ingredient, Glass/Shaker and Client
	 */
	void Interact() {
		// If click on ingredient always replace inventory with it
		if (hit.transform.IsChildOf (Ingredients)) {
			this.interactIngredient();
		}

		// If hit Equipment
		if (hit.transform.IsChildOf (Equipment)) {
			this.interactEquipment ();
		}

		if (hit.transform.IsChildOf (Clients)) {
			this.interactClient ();
		}
		// Empty Equipment if it hits the sink
		if(hit.transform.gameObject.name.Equals("Sink")) {
			this.emptyEquipment ();
		}
	}

	private void interactIngredient() {
		this.PickupItem ();
	}

	/*
	 * Raycast hits Equipment
	 */
	private void interactEquipment() {
		// If nothing in Inventory or other Equipment, pickup this!
		if (this.Inventory == null || this.Inventory.IsChildOf (Equipment))
			// this.pickupItem ();

		// If Ingredient in Inventory, mix it!
		if(this.Inventory.IsChildOf(Ingredients)) 
			hit.transform.SendMessage ("AddIngredient", Inventory);
	}

	/*
	 * Raycast hits Client
	 */
	private void interactClient() {
		if (this.Inventory != null) {
			hit.transform.SendMessage ("GetDrink", this.Inventory);
		}
		else {
			hit.transform.SendMessage ("SmallTalk");			
		}
	}
		
	void PickupItem() {
		if (!this.isPickedUpRight && !this.justDropped) {
			this.isPickedUpRight = true;
			this.RightItem = hit.transform;
			this.RightItem.gameObject.GetComponent<Rigidbody> ().useGravity = false;
		}
	}

	void DropItem() {
		if(this.isPickedUpRight) {
			this.isPickedUpRight = false;
			this.RightItem.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			this.RightItem = null;
			this.justDropped = true;
		}
	}

	void holdItem() {
		if(isPickedUpRight && !this.RightItem.Equals(null)) {
			this.RightItem.position = this.RightHand.transform.position;

			Debug.Log (this.RightItem.transform.rotation);

			if (Input.GetKey (KeyCode.E)) {
				this.fillIn ();
			} else {
				Quaternion targetRot = Quaternion.LookRotation (Vector3.up.normalized);
				RightItem.transform.rotation = Quaternion.Slerp (RightItem.transform.rotation, targetRot, Time.deltaTime * 5.0f);
			}
			if (Input.GetKey (KeyCode.E)) {
				this.fillIn ();
			}
		}
	}

	void fillIn() {
//		this.RightItem.transform.RotateAround (transform.position, transform.up, Time.deltaTime * 90f);
		this.RightItem.Rotate(Vector3.up * Time.deltaTime * 50.0f);
		Debug.Log ("fillIn");
	}

	/*
	 * Empty Equipment: Clear DrinkIngredients out of Equipment
	 */
	private void emptyEquipment() {
		if(this.Inventory.IsChildOf(Equipment)) {
			this.Inventory.GetComponent<DrinkController> ().EmptyEquipment ();
		}		
	}
}
