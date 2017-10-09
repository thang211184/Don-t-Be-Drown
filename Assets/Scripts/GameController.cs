using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	// Crates
	public GameObject crate;
	public Transform droppingPoint;
	public int crateCount;
	public float dropRate;

	// Score
	public GUIText scoreText;
	public int score;

	// Total crates on boat
	List<GameObject> totalCrates = new List<GameObject>{};

	void Start(){
		score = 0;
		StartCoroutine (SpawnWave ());
	}

	IEnumerator SpawnWave(){
		yield return new WaitForSeconds (dropRate);
		for (int i = 0; i < crateCount; i++) {
			Instantiate (crate, droppingPoint.position, droppingPoint.rotation);
			yield return new WaitForSeconds (dropRate);
		}
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		scoreUpdate ();
	}

	public void AddCrate(GameObject newCrate){
		totalCrates.Add (newCrate);
	}
		
	void scoreUpdate(){
		scoreText.text = "Score :" + score + "Crate: " + (totalCrates.Count + 1 );
	}

	void Update(){
		if (Input.GetKey(KeyCode.A)) {
			for (int i = 0; i <= totalCrates.Count; i++) {
				Destroy(totalCrates[i]);
			}
		}
	}
}
