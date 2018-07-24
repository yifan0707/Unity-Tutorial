using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour {
    public PlayerMove playerMove;
    [Range(2f,50f)]public float boostMultiplier;
    private float lerpTime;
    private bool boosting;
    [Range(0f, 2f)] public float maxBoostTime;
    private void Awake()
    {
        lerpTime = 0f;
        boosting = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            boosting = true;
        }
    }

    private void Update()
    {
        if (boosting)
        {
            if (lerpTime <= maxBoostTime)
            {
                lerpTime += Time.deltaTime;
                GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Lerp(boostMultiplier, playerMove.speed, lerpTime), 0, 0));
                print("Speed boost"+" "+boostMultiplier+" " + Mathf.Lerp(playerMove.speed, boostMultiplier, lerpTime));
            }
            else
            {
                boosting = false;
                lerpTime = 0f;
            }
        }
    }
}
