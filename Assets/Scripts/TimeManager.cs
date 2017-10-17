using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	public GUIText theText;

	// Use this for initialization
	void Start () {
		//theText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		startingTime -= Time.deltaTime;
		theText.text = Mathf.Round(startingTime).ToString();
	}
}
