using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 force;
    public float LiftSpeed;
    public float Turnspeed;
    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Thrust();
        Turn();
    }

    private void Thrust()
    {
        float thrustThisFrame = LiftSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

    }

    private void Turn()
    {
        rigidBody.freezeRotation = true;
        float rotationThisFrame = Turnspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.forward * rotationThisFrame);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false;
    }

}
