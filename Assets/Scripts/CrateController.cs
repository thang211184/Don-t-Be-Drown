using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
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
		other.attachedRigidbody(rb);
	}
}
