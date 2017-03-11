using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Container : MonoBehaviour {

	public string Name;
	public decimal MaxVol;
	public decimal Volume;

	protected Transform particleSource;
	protected Color liquidColor;
	protected RaycastHit hit;
	protected float range = 20f;

	protected Vector3 spawnPosition;
	protected float spawnTime = 5f;

	public ParticleSystem Particles;

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

	public void ReSpawn() {
		StartCoroutine (DelayedRespawn ());
	}

	IEnumerator DelayedRespawn() {
		yield return new WaitForSeconds(5);
		transform.position = spawnPosition;
		Initialize ();
	}

	protected abstract void Initialize ();
}