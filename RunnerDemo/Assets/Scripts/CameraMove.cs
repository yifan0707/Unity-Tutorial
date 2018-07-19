using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform player;
    float x_Distance;
	// Use this for initialization
	void Start () {
        x_Distance = player.position.x - this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tempPosition = this.transform.position;
        if (player != null)
        {
            tempPosition.x = player.position.x - x_Distance;
            this.transform.position = tempPosition;
        }
	}
}
