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

	// Create crates from above
	IEnumerator SpawnWave(){
		// Wait for few second before start dropping crates
		yield return new WaitForSeconds (dropRate);

		// Thuan, you can add sound of dropping crate here

		for (int i = 0; i < crateCount; i++) {
			// Create crate and drop it
			Instantiate (crate, droppingPoint.position, droppingPoint.rotation);
			yield return new WaitForSeconds (dropRate);
		}
	}

	// Add score to every catched crate
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		scoreUpdate ();
	}

	// Add crates to the list to destroy later when unload them at shelter station
	public void AddCrate(GameObject newCrate){
		totalCrates.Add (newCrate);
	}
		
	void scoreUpdate(){
		scoreText.text = "Score :" + score + "Crate: " + (totalCrates.Count + 1 );
	}

	void Update(){
		// Destroy crates( make it disappear) when unload at shelter
		if (Input.GetKey(KeyCode.A)) {
			for (int i = 0; i <= totalCrates.Count; i++) {
				Destroy(totalCrates[i]);
			}
		}
	}
}
