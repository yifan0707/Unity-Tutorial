using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour {

	private float result;
	public float testResult{
		get{ 

			return result;
		}
		set{ 
			result = value;
		}
	}
}
