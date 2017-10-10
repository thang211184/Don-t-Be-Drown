using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
	void OnTriggerExit(Collider other)
	{
		// When crates fall into water, it's disappear
		// Thuan, you can add sound of crate dropping into water here
		Destroy(other.gameObject);
	}
}
