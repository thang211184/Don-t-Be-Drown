using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject crate;
	public Transform droppingPoint;
	public int crateCount;
	public float dropRate;

	public GUIText scoreText;
	public int score;

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


	void scoreUpdate(){
		scoreText.text = "Score :" + score;
	}
}
