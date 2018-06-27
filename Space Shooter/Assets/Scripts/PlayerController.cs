using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}



public class PlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")&&Time.time>nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            this.GetComponent<AudioSource>().Play();
        }
        
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal")*speed;
        float moveVertical = Input.GetAxis("Vertical")*speed;

        rigidBody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.position = new Vector3 
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x*-tilt);
    }
}
