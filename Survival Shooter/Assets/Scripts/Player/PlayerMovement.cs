using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed=5f;
	private float vertical;
	private float horizontal;
	private Vector3 move;
	private Rigidbody player;
	private Animator playerAnimation;
	private LayerMask floorMask;

	void Awake(){
		player = GetComponent<Rigidbody> ();
		playerAnimation = GetComponent<Animator> ();
		floorMask = LayerMask.GetMask ("Floor");
	}

	void FixedUpdate(){
		vertical = Input.GetAxisRaw ("Vertical");
		horizontal = Input.GetAxisRaw ("Horizontal");
		Debug.Log (vertical);
		Move ();
		Rotation ();
		Animation ();
	}

	private void Move(){
		move.Set (horizontal, 0, vertical);
		move = move.normalized * Time.deltaTime * speed;

		player.MovePosition (move + transform.position);
	}

	private void Rotation(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, floorMask)) {
			Vector3 playerToPoint = hit.point - transform.position;
			playerToPoint.y = 0f;
			Quaternion rotation = Quaternion.LookRotation (playerToPoint);
			player.MoveRotation (rotation);
		}
	}
	private void Animation(){
		bool iswalking = vertical != 0f || horizontal != 0f;
		playerAnimation.SetBool ("IsWalking", iswalking);
	}
}
