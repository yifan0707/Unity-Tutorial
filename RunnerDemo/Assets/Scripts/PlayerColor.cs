using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {
    string currentColor;
    public Material yellowColor;
    public Material purpleColor;
    public Renderer playerRenderer;
    public PlayerHealth playerHealth;

    void Start()
    {
        currentColor = Constants.COLOR_YELLOW;
        playerRenderer = this.gameObject.GetComponent<Renderer>();
        playerRenderer.material = yellowColor;
    }

    void SwapColor()
    {
        if (currentColor == Constants.COLOR_PURPLE)
        {
            currentColor = Constants.COLOR_YELLOW;
            playerRenderer.material = yellowColor;
        }
        else if (currentColor == Constants.COLOR_YELLOW)
        {
            currentColor = Constants.COLOR_PURPLE;
            playerRenderer.material = purpleColor;
        }

    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SwapColor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            print("Touch the ground");
            if (other.CompareTag("YellowGround") && currentColor != Constants.COLOR_YELLOW)
            {
                playerHealth.PlayerDie();
            }
            else if(other.CompareTag("PurpleGround") && currentColor != Constants.COLOR_PURPLE)
            {
                playerHealth.PlayerDie();
            }
        }
    }

}
