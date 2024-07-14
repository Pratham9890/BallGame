using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Transform target;
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
        
        Vector3 movement = move(moveVertical,moveHorizontal);;
        //print(target.rotation.eulerAngles.y);
        if(target.rotation.eulerAngles.y==90)
        {
            movement = move(-moveHorizontal,moveVertical);
        }
        else if(target.rotation.eulerAngles.y==180)
        {
            movement = -movement;
        }
        else if(target.rotation.eulerAngles.y==270)
        {
            movement = move(moveHorizontal,-moveVertical);
        }
        //Apply force on ball
        rb.AddForce(movement*speed);

        //Limit max speed
        if (rb.velocity.magnitude > maxspeed) 
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
        }
    }
    //method to return a vector3 force which will push the ball
    Vector3 move(float moveVertical,float moveHorizontal) {
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        return movement;
    }
}
