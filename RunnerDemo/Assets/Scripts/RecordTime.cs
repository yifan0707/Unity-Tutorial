using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordTime : MonoBehaviour {
    public Text timeText;
    public float currentTime;
    public float finalTime;

    private void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update ()
    {
        currentTime += Time.deltaTime;
        UpdateText();
	}

    void UpdateText()
    {
       
        timeText.text = "Time: " + System.Math.Round(currentTime, 2);
    }

}
