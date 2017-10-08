using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject crate;
	public Transform droppingPoint;
	public int crateCount;
	public float dropRate;

	void Start(){
		StartCoroutine (SpawnWave ());
	}
	IEnumerator SpawnWave(){
		yield return new WaitForSeconds (dropRate);
		for (int i = 0; i < crateCount; i++) {
			Instantiate (crate, droppingPoint.position, droppingPoint.rotation);
			yield return new WaitForSeconds (dropRate);
		}
	}
}
