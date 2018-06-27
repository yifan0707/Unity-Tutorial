using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed=1f;
    [Range(1,10)]public float jumpMultiplier=1.2f;
    [Range(0,1)]public float maxJumpTime=0.3f;
    public float fallingGravity=1.5f;
    public float smallFallingGravity = 1.2f;

    private Rigidbody playerRigidbody;
    private bool isFirstJumping;
    private bool isDoubleJumping;
    private float jumpingTime;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start ()
    {
        isFirstJumping = false;
        isDoubleJumping = false;
        jumpingTime = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        addForwardForce();
        jump();
        ManageGravity();
    }

    private void addForwardForce()
    {
        playerRigidbody.AddForce(speed, 0, 0);
    }

    public void jump()
    {
        if (!isFirstJumping)
        {
            PerformJump();
            //setting the first jump status
            if (Input.GetButtonUp("Jump")) {
                isFirstJumping = true;
                jumpingTime = 0f;
                print("firstJumpCompleted");
            }
        }
        else if(!isDoubleJumping)
        {
            PerformJump();
            //setting the double jump status
            if (Input.GetButtonUp("Jump"))
            {
                isDoubleJumping = true;
                jumpingTime = 0f;
                print("SecondJumpCompleted");
            }
        }
    }

    private void PerformJump()
    {
        if (Input.GetButton("Jump") && jumpingTime < maxJumpTime)
        {
            playerRigidbody.velocity = playerRigidbody.velocity + Vector3.up * jumpMultiplier;
            jumpingTime += Time.deltaTime;
        }
    }

    private void ManageGravity()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Physics.gravity * fallingGravity * Time.deltaTime;
        }
        else if (!Input.GetButton("Jump") || jumpingTime > maxJumpTime)
        {
            playerRigidbody.velocity += Physics.gravity * smallFallingGravity * Time.deltaTime;
        }
    }

    private void TouchGround()
    {
        isFirstJumping = false;
        isDoubleJumping = false;
    }

}
