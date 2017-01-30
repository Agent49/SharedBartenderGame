﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PersonContoller : MonoBehaviour {

	public UiController Ui;
	public Transform Inventory;

	private bool isPickedUpLeft;
	private bool isPickedUpRight;
	private bool justDropped;
	private float range = 10f;
	private RaycastHit hit;
	private Transform leftItem;
	private Transform rightItem;
	private Transform leftHand;
	private Transform rightHand;
	private Transform ingredients;
	private Transform equipment;
	private Transform clients;

	/*
	 * Initialize often used members once which were declared above
	 */
	void Start () {
		isPickedUpRight = false;
		leftHand = gameObject.transform.GetChild (0);
		rightHand = gameObject.transform.GetChild (1);
		// Load UiController in order to execute member functions
		Ui = GameObject.FindGameObjectWithTag("DebugUI").GetComponent<UiController>();
		ingredients = GameObject.Find ("Ingredients").transform;
		equipment = GameObject.Find ("Equipment").transform;
		clients = GameObject.Find ("Clients").transform;
	}

	/*
	 * Check for user inputs and call permament functions if activated
	 */
	void Update () {	

		// Drop Inventory
		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2")) {
			DropItem ();
		}

		CheckForHit ();

		HoldItem ();

		justDropped = false;

		if (isPickedUpRight) {
			HoldItem ();
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
				if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2"))
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
		if (hit.transform.IsChildOf (ingredients)) {
			InteractIngredient();
		}

		// If hit Equipment
		if (hit.transform.IsChildOf (equipment)) {
			InteractEquipment ();
		}

		if (hit.transform.IsChildOf (clients)) {
			InteractClient ();
		}
		// Empty Equipment if it hits the sink
		if(hit.transform.gameObject.name.Equals("Sink")) {
			EmptyEquipment ();
		}
	}

	/*
	 * Ingredients are to pickup, mix and so on
	 */
	private void InteractIngredient() {
		PickupItem ();
	}

	/*
	 * Raycast hits Equipment
	 */
	private void InteractEquipment() {
		// If nothing in Inventory or other Equipment, pickup this!
		if (Inventory == null || Inventory.IsChildOf (equipment))
			// pickupItem ();

		// If Ingredient in Inventory, mix it!
		if(Inventory.IsChildOf(ingredients)) 
			hit.transform.SendMessage ("AddIngredient", Inventory);
	}

	/*
	 * Raycast hits Client
	 */
	private void InteractClient() {
		if (Inventory != null) {
			hit.transform.SendMessage ("GetDrink", Inventory);
		}
		else {
			hit.transform.SendMessage ("SmallTalk");			
		}
	}

	/*
	 * Pickup an item with the left or right hand
	 */
	private void PickupItem() {
		if (Input.GetButtonDown("Fire1") && !isPickedUpLeft && !justDropped) {
			isPickedUpLeft = true;
			leftItem = hit.transform;
			leftItem.gameObject.GetComponent<Rigidbody> ().useGravity = false;
		} else if (Input.GetButtonDown("Fire2") && !isPickedUpRight && !justDropped) {
			isPickedUpRight = true;
			rightItem = hit.transform;
			rightItem.gameObject.GetComponent<Rigidbody> ().useGravity = false;
		} 
	}

	/*
	 * Drop an item you hold in your left or right hand
	 */
	private void DropItem() {
		if(Input.GetButtonDown ("Fire1") && isPickedUpLeft) {
			isPickedUpLeft = false;
			leftItem.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			leftItem = null;
			justDropped = true;
		}
		else if(Input.GetButtonDown ("Fire2") && isPickedUpRight) {
			isPickedUpRight = false;
			rightItem.gameObject.GetComponent<Rigidbody> ().useGravity = true;
			rightItem = null;
			justDropped = true;
		}
	}

	/*
	 * After picking up an item once, hold it all along the frames within update()
	 */
	private void HoldItem() {
		if(isPickedUpLeft && !leftItem.Equals(null)) {
			leftItem.position = leftHand.transform.position;

			if (Input.GetKey (KeyCode.Q)) {
				FillIn ();
			} else {
//				Quaternion targetRot = Quaternion.LookRotation (Vector3.up.normalized);
//				leftItem.transform.rotation = Quaternion.Slerp (leftItem.transform.rotation, targetRot, Time.deltaTime * 5.0f);
			}
		}
		if(isPickedUpRight && !rightItem.Equals(null)) {
			rightItem.position = rightHand.transform.position;

			if (Input.GetKey (KeyCode.E)) {
				FillIn ();
			} else {
				Quaternion targetRot = Quaternion.LookRotation (Vector3.up.normalized);
				rightItem.transform.rotation = Quaternion.Slerp (rightItem.transform.rotation, targetRot, Time.deltaTime * 5.0f);
			}
		}
	}

	/*
	 * Simulates a fill-in movement by rotation the object
	 */
	private void FillIn() {
		if(Input.GetKey(KeyCode.Q)) {
			leftItem.Rotate(-Vector3.up * Time.deltaTime * 50.0f);
			float angle = leftItem.transform.localEulerAngles.x;
			if ((0.0f < angle) && (angle < 180.0f)) {
				Debug.Log (angle);
			}
		} 
		else if(Input.GetKey(KeyCode.E)) 
		{
			rightItem.Rotate(Vector3.up * Time.deltaTime * 50.0f);			
		}
	}

	/*
	 * Empty Equipment: Clear DrinkIngredients out of Equipment
	 */
	private void EmptyEquipment() {
		if(Inventory.IsChildOf(equipment)) {
			Inventory.GetComponent<DrinkController> ().EmptyEquipment ();
		}		
	}
}
