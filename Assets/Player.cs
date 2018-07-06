using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 6.5f;
	public float jumpingForce = 300f;
	public float jumpingCoolDown = 1.5f;
	public float jumpingTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// Move player forward
		transform.position += speed * Vector3.forward * Time.deltaTime;

		jumpingTimer -= Time.deltaTime;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began || Input.GetKeyDown("space")) {
			if (jumpingTimer <= 0.0f) {
				jumpingTimer = jumpingCoolDown;
				GetComponent<Rigidbody>().AddForce(Vector3.up * jumpingForce);
			}

		}
	}
}
