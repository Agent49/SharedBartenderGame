using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Container : MonoBehaviour {

	public decimal maxVol;
	protected Transform particleSource;
	protected Color liquidColor;
	protected RaycastHit hit;

	public ParticleSystem Particles;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void InitializeParticleSystem() {
		if (transform.childCount == 1) {
			particleSource = gameObject.transform.GetChild (0);
			Particles = particleSource.GetComponent<ParticleSystem> ();
			if (liquidColor != null){
				// Overwriting Particles.main is not permitted
				var particlesMain = Particles.main;
				particlesMain.startColor = liquidColor;
			}
			else{
				Debug.LogError ("No Color was set.");
			}
		} else {
			Debug.LogError ("Failed InitializeParticleSystem(): There must be exactly 1 child.");
		}
	}

	protected abstract void Initialize ();

	public abstract void FlowOut ();
}