using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Engine : MonoBehaviour {
    public Transform path;
    private List<Transform> nodes;
    private int currNode = 0;

    public float steerAngle = 40f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;

	// Use this for initialization
	void Start () {
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
        ApplySteer();
        Drive();
        CheckNodeDistance();
	}

    private void ApplySteer(){
        Vector3 relVector = transform.InverseTransformPoint(nodes[currNode].position);
        //print(relVector);
        //relVector = relVector / relVector.magnitude; // length of relative vector
        float newSteer = (relVector.x / relVector.magnitude) * steerAngle; // value of angle of wheel colliders
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive(){
        wheelFL.motorTorque = 50;
        wheelFR.motorTorque = 50;
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
}
