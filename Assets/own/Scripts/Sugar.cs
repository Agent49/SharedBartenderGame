using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Sugar : MonoBehaviour {

	private string Name;
	private Vector3 spawnPosition;
	private DrinkContainer drinkContainer;
	Regex rgx = new Regex(@"[\b\s-_]+");

	// Use this for initialization
	void Start () {
		// Derive Sugar from gameObject name
		Name = rgx.Split(transform.name)[0];
		spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		drinkContainer = other.gameObject.GetComponent<DrinkContainer> ();
	}

	void OnTriggerStay() {
		GetSugar ();
	}

	/*
	 * Sugar falls down the glass
	 */
	private bool GetSugar() {

		if(drinkContainer != null) {
			// Provides falling down the glass and used as flag for: not in hands anymore
			transform.gameObject.GetComponent<BoxCollider> ().enabled = false;
			return true;
		}
		return false;
	}

	void OnTriggerExit(Collider other) {
		drinkContainer = other.gameObject.GetComponent<DrinkContainer> ();
		AddSugar ();
	}

	private bool AddSugar() {
		// dropItem() enables the Collider. What happend last?
		if (transform.gameObject.GetComponent<BoxCollider> ().enabled || 
			!transform.gameObject.GetComponent<Rigidbody> ().useGravity ||
			(drinkContainer == null))
			return false;
		
		// If Collider still is disabled then last thing happend is falling into a glas
		foreach(Transform child in drinkContainer.gameObject.transform) {
			if (Name.Equals (rgx.Split (child.name) [0])) {
				child.gameObject.SetActive (true);
				drinkContainer.GiveMeSugarBaby (Name);
			}				
		}

		ReSpawn(0.1f);

		return true;
	}
		
	public void ReSpawn(float spawnTime) {
		StartCoroutine (DelayedRespawn (spawnTime));
	}

	IEnumerator DelayedRespawn(float spawnTime) {
		yield return new WaitForSeconds(spawnTime);
		transform.gameObject.GetComponent<BoxCollider> ().enabled = true;
		transform.rotation = Quaternion.LookRotation (Vector3.up);
		transform.position = spawnPosition;
	}
}
