using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    public Transform path;
    private List<Transform> nodes; //define nodes again in the AI controller to get all the nodes of the path
    private int currentNode = 0; //set index of nodes to 0

    Rigidbody AIRigidBody;
    public WheelCollider right;
    public WheelCollider left;
    public float speed = 50f; //moving forward along z axis
    public float turningAngle = 40f; //how much the ai will turn by
    public float flightForce = 50; //used to push vehicle off the ground allowing it to hover
    public float flightHeight = 5;

    void Start()
    {
        //using path.GetComponentsInChildren so that the child nodes are retrieved from the path and not trying to get them from the AI car
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>(); 
        nodes = new List<Transform>(); //empty the list at the beginning

        for (int i = 0; i < pathTransform.Length; i++) //loops through each transform and picks one out
        {
            if (pathTransform[i] != path.transform) //checks if it's our own path transform
            {
                nodes.Add(pathTransform[i]); //if not then it adds it to the nodes array
            }
        }
    }

    void Awake()
    {
        AIRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate () {
        Turning();
        Forward();
        WaypointDist();

        Ray ray = new Ray(transform.position, -transform.up); //casting a ray from position of the vehicle downwards
        RaycastHit hit;

        //cast a ray to check if within the flight distance of the ground
        //if within the distance of flight height then push the UFO away from the ground to hover
        if (Physics.Raycast(ray, out hit, flightHeight))
        {
            float height = (flightHeight - hit.distance) / flightHeight;
            Vector3 appliedForce = Vector3.up * height * flightForce; //scale force based upon the height
            AIRigidBody.AddForce(appliedForce, ForceMode.Acceleration); //ForceMode ignores the mass of the vehicle allowing it to float
        }
    }

    private void Turning()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float Turn = (relativeVector.x / relativeVector.magnitude) * turningAngle; //magnitude = the length of the vector
        right.steerAngle = Turn;
        left.steerAngle = Turn;
    }

    private void Forward()
    {
        AIRigidBody.AddRelativeForce(0f, 0f, speed);
    }

    private void WaypointDist()
    {
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.05f)
        {
            if(currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }else
            {
                currentNode++;
            }
        }
    }
}
