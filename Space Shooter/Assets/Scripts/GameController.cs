using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject asteroid;
    public float width, height,spawnWait,waveWait;
    public int asteroidCount;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
	// Use this for initialization
	void Start () {
        StartCoroutine (spawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator spawnWaves() {
        while (true) {
            for (int i = 0; i < asteroidCount; i++)
            {
                Debug.Log("hazard created");
                spawnPosition = new Vector3(Random.Range(-width, width), 0, height);
                spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
