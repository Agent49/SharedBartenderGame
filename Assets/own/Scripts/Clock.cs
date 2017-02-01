using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public TextMesh ClockText;
	private float ClockTime;

	// Use this for initialization
	void Start () {
		ClockTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ClockTime += Time.deltaTime;
		ClockText.text = ClockTime.ToString ("00:00");
		
	}
}
