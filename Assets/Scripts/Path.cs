using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public Color pathColor;

    private List<Transform> nodes = new List<Transform>(); //store the nodes in a list

    void OnDrawGizmos()
    {
        Gizmos.color = pathColor; //Gizmos used to visualise path in unity editor, executed when scene view updates

        //loop through array, if the transform isn't our own then it is pushed to the nodes
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>(); //empty the list at the beginning

        for(int i = 0; i < pathTransform.Length; i++) //loops through each transform and picks one out
        {
            if(pathTransform[i] != transform) //checks if it's our own transform
            {
                nodes.Add(pathTransform[i]); //if not then it adds it to the nodes array
            }
        }

        //for loop to draw lines between nodes to allow us to see the path
        for(int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position; //current position of the node
            Vector3 previousNode = Vector3.zero;

            if (i > 0)
            {
                //previous position is node in index - 1
                //if not on index 0 then you take the previous node - 1
                previousNode = nodes[i - 1].position; 
            }
            else if(i == 0 && nodes.Count > 1)
            {
                //if you are on index 0 then you take the previous node - last node in the array
                //this stops the path from trying to draw a line from 0 to -1 but instead it draws from 0 to the last node in the array
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode); //using Gizmos funtion to draw coloured line between each node
            Gizmos.DrawSphere(currentNode, 2f); //displays a sphere at each node in the path
        }
    }
}
