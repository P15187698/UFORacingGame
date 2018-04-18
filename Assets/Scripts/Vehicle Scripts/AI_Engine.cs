using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Engine : MonoBehaviour {
    public Transform path;
    private List<Transform> nodes;
    private int currNode = 0;

    public Vector3 centerOfMass;

    [Header("Engine")]
    public float maxMotorTorque = 50f;
    public float maxSpeed = 500f;
    public float currentSpeed;
    public float maxBrakeTorque = 300f;
    public bool braking = false;

    [Header("Wheels")]
    public float steerAngle = 40f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass; // instead of mass being set at 0, 0, 0 i can set my own position, makes vehicle more stable

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>(); //empty the list at the beginning

        for (int i = 0; i < pathTransform.Length; i++) //loops through each transform and picks one out
        {
            if (pathTransform[i] != path.transform) //checks if it's our own transform
            {
                nodes.Add(pathTransform[i]); //if not then it adds it to the nodes array
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Steer();
        Drive();
        CheckNodeDistance();
        Brake();
	}

    private void Steer(){
        Vector3 relVector = transform.InverseTransformPoint(nodes[currNode].position);
        float newSteer = (relVector.x / relVector.magnitude) * steerAngle; // value of angle of wheel colliders
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive(){
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm; // calculates current speed based on how fast wheel is spinning
        if(currentSpeed < maxSpeed && !braking) // if current speed is less than max speed and the ufo isnt braking, apply wheel torque
        {
            wheelFL.motorTorque = maxSpeed;
            wheelFR.motorTorque = maxSpeed;
        }
        else // otherwise setting torque to 0 and let the vehicle roll
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
        
    }

    private void Brake()
    {
        if (braking) // set the brakes to the max brake torque so the ufo will slow down
        {
            wheelBL.brakeTorque = maxBrakeTorque;
            wheelBR.brakeTorque = maxBrakeTorque;
        }
        else // otherwise set the brakes to 0 so the ufo will continue at the current speed
        {
            wheelBL.brakeTorque = 0;
            wheelBR.brakeTorque = 0;
        }
    }

    private void CheckNodeDistance()
    {
        if(Vector3.Distance(transform.position, nodes[currNode].position) < 1.0f)
        {
            if(currNode == nodes.Count - 1)
            {
                currNode = 0;
            }else {
                currNode++;
            }
        }
    }

    void OnTriggerStay(Collider other) // whilst the ai is in inside the trigger it does the following
    {
        // if the ai collides with an object with the tag "BrakingSector" it will set braking to true
        // this only happens in the time span that the ai is inside the tagged trigger
        if (other.tag == "BrakingSector") 
        {
            braking = true;
        }
    }

    void OnTriggerExit(Collider other) // when the ai exits the braking sector it sets braking back to false
    {
        if (other.tag == "BrakingSector")
        {
            braking = false;
        }
    }
}
