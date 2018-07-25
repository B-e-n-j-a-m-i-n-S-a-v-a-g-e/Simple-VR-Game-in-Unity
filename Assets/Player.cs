using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 6.5f;
	public float jumpingForce = 300f;
	public float jumpingCoolDown = 1.5f;
	public float jumpingTimer = 0f;
	public float acceleration = 1.0f;

	public GameObject startText;

	public bool levelBegin = false;

	private float speed = 0.0f;

	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began || Input.GetKeyDown ("space")) {
			levelBegin = true;
			startText.SetActive (false);
		}

		if (levelBegin) {

			speed += acceleration * Time.deltaTime;

			if (speed > maxSpeed) {
				speed = maxSpeed;
			}

			transform.position += transform.forward * speed * Time.deltaTime;

			jumpingTimer -= Time.deltaTime;

			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began || Input.GetKeyDown ("space") && levelBegin) {
				if (jumpingTimer <= 0.0f) {
					jumpingTimer = jumpingCoolDown;
					GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpingForce);
				}
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Obstacle") {
			speed *= 0.5f;
		} else if (collider.tag == "FinishLine") {
			levelBegin = false;
			transform.position = Vector3.zero;
			startText.SetActive (true);
		}
	}
}
