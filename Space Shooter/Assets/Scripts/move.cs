using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,speed);
        //this.GetComponent<Rigidbody>().velocity =transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
