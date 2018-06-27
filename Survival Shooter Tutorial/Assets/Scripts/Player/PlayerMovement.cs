using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Rigidbody playerRigidbody;
    Animator playerAnimator;
    Vector3 playerMovement;
    LayerMask floorMask;
    float camRayLength = 100f;// the length of the ray from the camera into the scene.

    /**
     * This method will be called once the game started and this function's main functions are assigning
     * default values. Eg. assigning rigidbody
     * 
     **/
    void Awake() {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    /**
     * This method will be called everyframe and mainly handling input and anything that need fixed updates
     **/ 
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");//default axis name for left and right movement
        float h = Input.GetAxisRaw("Horizontal");//default axis name for up and down movement
        Debug.Log(1+v);
        Move(v,h);
        Animation(v,h);
        Rotation();
    }

    private void Move(float v, float h)
    {
        playerMovement.Set(v, 0, h);
        playerMovement = playerMovement.normalized * Time.deltaTime * speed;//normalize the vector 3 movement
        playerRigidbody.MovePosition(playerMovement + transform.position);
    }

    private void Animation(float v, float h) {
        bool isWalking = (v != 0f || h != 0f);
        Debug.Log(isWalking);
        playerAnimator.SetBool("IsWalking", isWalking);
    }

    private void Rotation() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(ray, out floorHit, camRayLength, floorMask)) {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion rotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(rotation);
        }

    }
}
