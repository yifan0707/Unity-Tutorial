using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed=5f;
    [Range(1,20)]public float jumpMultiplier=10f;

    private float maxHeight=7f;

    public float fallingGravity=1.5f;
    public float smallFallingGravity = 1.2f;

    private Rigidbody playerRigidbody;
    private bool isFirstJumpAvail;
    private bool isSecondJumpAvail;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start ()
    {
        isFirstJumpAvail = false;
        isSecondJumpAvail = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        AddForwardForce();
        Jump();
        ManageGravity();
    }

    private void AddForwardForce()
    {
        playerRigidbody.AddForce(speed, 0, 0);
    }

    public void Jump()
    {
        if (isFirstJumpAvail)
        {
            if (Input.GetButtonDown("Jump"))
            {
                playerRigidbody.velocity = playerRigidbody.velocity + Vector3.up * jumpMultiplier;
                isFirstJumpAvail = false;
            }
            
        }
        else if(isSecondJumpAvail)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector3 tempVelocity = playerRigidbody.velocity;
                tempVelocity.y = 0f;
                playerRigidbody.velocity = tempVelocity;

                playerRigidbody.velocity = playerRigidbody.velocity + Vector3.up * jumpMultiplier;
                isSecondJumpAvail = false;
            }
        }


    }



    private void ManageGravity()
    {
        if (!isFirstJumpAvail && playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Physics.gravity * fallingGravity * Time.deltaTime;
        }
        else
        {
            playerRigidbody.velocity += Physics.gravity * smallFallingGravity * Time.deltaTime;
        }
    }

    private void TouchGround()
    {
        isFirstJumpAvail = true;
        isSecondJumpAvail = true;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (!isFirstJumpAvail)
        {
            TouchGround();
        }

    }
}
