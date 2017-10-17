using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	// Crates
	public GameObject crate;
	public GameObject boat;
	public Transform droppingPoint;
	public int crateCount;
	public float dropRate;

	// Time
	public float startingTime;
	public GUIText theText;

	// Score
	public GUIText scoreText;
	public int score;

	// Hint
	public GUIText hintText;

	// Total crates on boat
	GameObject[] totalCrates ;

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
			float x = Random.Range(-3, 3);
            float y = 4.96f;
            float z = 0;
            Vector3 pos = new Vector3(x, y, z);
            droppingPoint.position = pos;
			Instantiate (crate, droppingPoint.position, droppingPoint.rotation);
			yield return new WaitForSeconds (dropRate);
		}
	}
		

	// Add crates to the list to destroy later when unload them at shelter station
	/*public void AddCrate(GameObject newCrate){
		totalCrates.Add (newCrate);
	}*/
		
	void scoreUpdate(){
		scoreText.text = "Score :" + score.ToString();
	}

	void Update(){
		// Time counting
		startingTime -= Time.deltaTime;
		theText.text = Mathf.Round(startingTime).ToString();


		// Unload crates
		if (Input.GetKey(KeyCode.Z)) {
			if (boat.transform.position.x < -7.5) {
				/*for (int i = 0; i <= totalCrates.Count; i++) {
					Destroy (totalCrates [i]);
				}*/
				totalCrates = GameObject.FindGameObjectsWithTag("Crate");
				for (int i = 0; i < totalCrates.Length; i++) {
					Destroy (totalCrates [i]);
					score += 1;
					scoreUpdate ();
				}
				//hintText.text = "Thank you very muchhhhhhhhhhhhh";
			} else {
				hintText.text = "please go to shelter to unload crates";
			}
				return;
		}

		// Winning condition 
		if (startingTime <= 0) {
			if (score >= 2) {
				hintText.text = " you win";
			} else {
				SceneManager.LoadScene (3);
			}
		}
	}


}
