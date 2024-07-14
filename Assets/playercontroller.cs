using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Transform target; // Assuming this is the camera's transform
    public float maxspeed;
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        // Calculate movement direction based on camera's forward direction
        Vector3 cameraForward = target.forward;
        Vector3 cameraRight = target.right;
        cameraForward.y = 0f; // Ensure the direction is strictly horizontal

        // Calculate movement direction based on camera's rotation
        Vector3 movement = cameraForward * moveVertical + cameraRight * moveHorizontal;

        // Apply force to the rigidbody
        rb.AddForce(movement * speed);

        // Limit max speed
        if (rb.velocity.magnitude > maxspeed)
        {
            rb.velocity = rb.velocity.normalized * maxspeed;
        }
    }
}
