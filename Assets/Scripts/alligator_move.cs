using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alligator_move : MonoBehaviour {
    public Transform target;//set target from inspector instead of looking in Update
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        target = GameObject.FindWithTag("Boat").transform;

        float step = speed * Time.deltaTime;
        Vector3 offset = new Vector3(0, -1.7f, 0);
        Vector3 targetHeading = target.position + offset;
        //Vector3 targetDirection = targetHeading.normalized;

        transform.position = Vector3.MoveTowards(transform.position, targetHeading, step);

        //Vector3 position = new Vector3(Random.Range(-1, 1), 0, 0);
        //transform.Translate(Vector3.MoveTowards(Vector3.curr* Time.deltaTime, Camera.main.transform);
    }
}
