using System.Collections; using System.Collections.Generic; using UnityEngine; using UnityEngine.UI;

public class PlayerController : MonoBehaviour { 	private Rigidbody rb;     public Text countText;     public Text winText;  	public int velocity;     private int count; 	// Use this for initialization 	void Start () { 		rb = GetComponent<Rigidbody> ();
        count = 0;         SetCountTest();
        winText.text = "";
    } 	 	// Update is called once per frame 	void Update () { 		float moveHorizontal = Input.GetAxis ("Horizontal"); 		float moveVertical = Input.GetAxis ("Vertical"); 		Vector3 movement = new Vector3 (velocity*moveHorizontal, 0.0f, velocity*moveVertical); 		rb.AddForce (movement); 	}      void OnTriggerEnter(Collider other)     {         if(other.gameObject.CompareTag("Pick Up"))         {             other.gameObject.SetActive(false);             count = count + 1;             SetCountTest();         }     }      void SetCountTest()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 21)
        {
            winText.text = "You win!";
        }
    } } 