using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float smoothing=5f;
	public GameObject target;
	private Vector3 offset;

	void Awake(){
		offset=transform.position-target.transform.position;
	}

	void FixedUpdate(){
		transform.position = Vector3.Lerp (transform.position, target.transform.position + offset, smoothing*Time.deltaTime);
	}
}
