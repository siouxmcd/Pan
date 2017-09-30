using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBodyVelocity : MonoBehaviour {
    public int speed = 10;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
