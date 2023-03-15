using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_12 : MonoBehaviour
{
    public WheelCollider forntright;
    public WheelCollider forntleft;
    public WheelCollider backright;
    public WheelCollider backrleft;
    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform backRightTransform;
    public Transform backLeftTransform;
    public float acceleration = 500f;
    public float breakingforce = 300f;
    private float currentacceleration = 500f;
    private float currentbreakingforce = 300f;
    public float maxTurnAngle = 15f;
    public float TurnAnglesens = 1f;
    private float currentTurnAngle = 0f;
    public Vector3 cam;
    public Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = cam;
    }
    private void FixedUpdate()
    {
        currentacceleration = acceleration * Input.GetAxis("Vertical");
        //apple move

        backright.motorTorque = currentacceleration;
        backrleft.motorTorque = currentacceleration;
        //left right
        currentTurnAngle = TurnAnglesens * maxTurnAngle * Input.GetAxis("Horizontal");
        forntright.steerAngle = currentTurnAngle;
        forntleft.steerAngle = currentTurnAngle;


        if (Input.GetKey(KeyCode.Space))
        {
            currentbreakingforce = breakingforce;
        }
        else
        {
            currentbreakingforce = 0f;
        }
        forntright.brakeTorque = currentbreakingforce;
        forntleft.brakeTorque = currentbreakingforce;
        backright.brakeTorque = currentbreakingforce;
        backrleft.brakeTorque = currentbreakingforce;


        //Update wheel meashes
        UpdateWheel(forntright, frontRightTransform);
        UpdateWheel(forntleft, frontLeftTransform);
        UpdateWheel(backright, backRightTransform);
        UpdateWheel(backrleft, backLeftTransform);




    }
    public void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get Wheel collider state.
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        // set Wheel transform state.
        trans.position = position;
        trans.rotation = rotation;
    }
}
