﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

	public TextMesh ClockText;
	private float ti;

	// Use this for initialization
	void Start () {
		ti = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// ti += Time.deltaTime;
		// ClockText.text = ti.ToString ("00:00");
		
	}
}