using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEngine : MonoBehaviour {

    //engine variables
    float power;
    float turning;
    Rigidbody UfoRigidBody;

    public float speed = 50f; //moving forward along z axis
    public float turningSpeed = 10f; //speed at which you rotate along y axis when turning
    public float flightForce = 50; //used to push vehicle off the ground allowing it to hover
    public float flightHeight = 5;

    void Awake () {
        UfoRigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        power = Input.GetAxis("Vertical"); //use W/S and Up/Down arrows to drive UFO Forward/backward
        turning = Input.GetAxis("Horizontal");
	}

    void FixedUpdate(){
        Ray ray = new Ray(transform.position, -transform.up); //casting a ray from position of the vehicle downwards
        RaycastHit hit;

        //cast a ray to check if within the flight distance of the ground
        //if within the distance of flight height then push the UFO away from the ground to hover
        if (Physics.Raycast(ray, out hit, flightHeight)){
            float height = (flightHeight - hit.distance) / flightHeight;
            Vector3 appliedForce = Vector3.up * height * flightForce; //scale force based upon the height
            UfoRigidBody.AddForce(appliedForce, ForceMode.Acceleration); //ForceMode ignores the mass of the vehicle allowing it to float
        }
        //this allows you to move forward and backwards on the x axis without moving in the z or y axis
        UfoRigidBody.AddRelativeForce(power * speed, 0f, 0f);

        //using relative torque to rotate the UFO around the y axis which is used for turning the vehicle left/right
        UfoRigidBody.AddRelativeTorque(0f, turning * turningSpeed, 0f); 
    }
}
