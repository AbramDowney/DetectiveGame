using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float forwardSpeed;
    public float LRSpeed;

    void Start() {
         
    }

    void FixedUpdate()
    {
        if(Input.GetKey("w")){
            playerRB.AddForce(transform.forward * forwardSpeed * Time.deltaTime);
        }

        if(Input.GetKey("s")){
            playerRB.AddForce(-transform.forward * forwardSpeed * Time.deltaTime);
        }

        if(Input.GetKey("d")){
            playerRB.AddForce(LRSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a")){
            playerRB.AddForce(-LRSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}