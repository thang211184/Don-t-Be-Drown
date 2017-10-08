using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachOnContact : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		Debug.Log (other.name);
		other.transform.parent = gameObject.transform;
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		Debug.Log (other.name);
		other.transform.parent = null;
	}

}
