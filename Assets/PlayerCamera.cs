﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public float movementAmplitude = 0.1f;
	public float movementFrequency = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Make player bounce
		transform.localPosition = new Vector3 (transform.localPosition.x,
			Mathf.Cos(transform.position.z * movementFrequency) * movementAmplitude,	
			transform.localPosition.z);



	}
}
