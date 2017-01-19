using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidAngle : MonoBehaviour {

	public ParticleSystem Liquid;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.x < 180 && transform.rotation.x > 0) {
			Liquid.Play();
		} else {
			Liquid.Stop();
		}
		
	}
}
