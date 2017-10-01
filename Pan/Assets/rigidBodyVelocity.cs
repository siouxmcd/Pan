using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBodyVelocity : MonoBehaviour {
    public float speed = 0.1f;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
