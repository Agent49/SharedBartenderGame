using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidAngle : MonoBehaviour {

	public ParticleSystem Liquid;
    public TextMesh DebugText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var em = Liquid.emission;
        double fluss;
       
		if (transform.rotation.eulerAngles.x < 90) {
			Liquid.Play();
            fluss = transform.rotation.eulerAngles.x * 2.5;

            em.rateOverTime = System.Convert.ToSingle(fluss);
            DebugText.text = fluss.ToString();
        } else {
			Liquid.Stop();
		}
		
	}
}
