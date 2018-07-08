using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public TextMesh infoText;

	private float gameTimer = 0f;
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (player.levelBegin == true) {
			gameTimer += Time.deltaTime;
			infoText.text = "Time: " + Mathf.Floor (gameTimer);
		} else {
			infoText.text = "";
		}
	}
}
