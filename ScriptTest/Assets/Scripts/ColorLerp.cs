using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour {

	public float colorTransformationTime= 0.5f;
	private float result;
	private float initialTime;

	void Start(){
		initialTime = Time.time;
	}

	void Update(){
		ChangeColor (Time.time - initialTime);
	}

	private void ChangeColor(float t){
		GetComponent<Renderer>().material.color = Color.Lerp (Color.red, Color.blue, t*colorTransformationTime);
	}


}
