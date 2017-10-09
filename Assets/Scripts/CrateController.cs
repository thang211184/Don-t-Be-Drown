using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	public int scoreValue;
	private GameController gameController;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void FixedUpdate()
	{
		rb.AddForce(0, -10, 0);
		//rb.AddForce (1, 0, 0);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		gameObject.transform.parent = other.transform;
		rb.isKinematic = true;
		gameController.AddScore (scoreValue);
		gameController.AddCrate (gameObject);
	}
}
