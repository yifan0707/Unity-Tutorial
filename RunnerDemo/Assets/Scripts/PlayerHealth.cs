using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public ParticleSystem particle;
    public Transform player;
    // Use this for initialization
    private void Awake()
    {
        player = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update () {
        if (player.position.y < -10)
        {
            PlayerDie();
        }
	}

    public void PlayerDie()
    {
        Destroy(particle.gameObject);
        Destroy(this.gameObject);
    }


}
