using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject playerExplosion;
    public GameObject asteroidExplosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Boundary"))
        {
            return;
        }
        else {
            Instantiate(asteroidExplosion, this.transform.position, this.transform.rotation);
            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        
    }
}
