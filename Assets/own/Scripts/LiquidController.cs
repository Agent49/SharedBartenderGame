using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidController : MonoBehaviour {

	private float range = 10f;

	public ParticleSystem Liquid;
	private Transform ParticleSource;
	private RaycastHit hit;

	private static Transform ingredients;
	// Use this for initialization
	void Start () {
		ParticleSource = gameObject.transform.GetChild (0);
		// This function will be called for each attachement to a GameObject
		// ingredients = GameObject.Find ("Ingredients").transform;
	}
	
	// Update is called once per frame
	void Update () {
        double flow;
       
		if (transform.rotation.eulerAngles.x < 90) {
			Liquid.Play();
			Debug.DrawRay (ParticleSource.position, Vector3.down, Color.red, 1);
			if(Physics.Raycast(ParticleSource.position, Vector3.down, out hit)) {
				if (hit.transform.tag.Equals ("Equipment"))
					Debug.Log ("Equipment!");
			}
        } else {
			Liquid.Stop();
		}
		
	}

	private void FillIn() {
		
	}
}
