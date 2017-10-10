using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateController : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	public int scoreValue;
	private GameController gameController;
    public GameObject windZone;
    public bool isWindZone = false;



	void Start()
	{
		rb = GetComponent<Rigidbody>();

		// Make GameController and CrateConller wort together
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

	// Nothing here yet
	void Update(){
		
	}

	// Add force to crate
	void FixedUpdate()
	{
		// Add downward force
		rb.AddForce(0, -10, 0);
        if(windZone)
        rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
		// Need to add wind force here or we can make wind like Giang suggest
		//rb.AddForce (1, 0, 0);
	}

	// When crate touch the boat, it'll stay at the contact point

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}
		Debug.Log (other.name);
		// Thuan, we can add sound here
		gameObject.transform.parent = other.transform;
		rb.isKinematic = true;
		gameController.AddScore (scoreValue);
		gameController.AddCrate (gameObject);

        if (other.tag == "windarea")
        {
            windZone = other.gameObject;
            isWindZone = true;
        }
	}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "windarea")
        { isWindZone = false; }
    }
}
