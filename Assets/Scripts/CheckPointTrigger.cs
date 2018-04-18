using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {
    public GameObject FinishLine;
    public GameObject CheckPoint;
    void OnTriggerEnter (){
        //this sets the lapfinish variable to true
        FinishLine.SetActive (true); //it turns it on in the game world

        CheckPoint.SetActive (false); 
    }
}
