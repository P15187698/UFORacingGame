using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {
    public GameObject LapFinish;
    public GameObject CheckPointTrig;

    void OnTriggerEnter (){
        //this sets the lapfinish variable to true
        LapFinish.SetActive(true); //it turns it on in the game world

        CheckPointTrig.SetActive(false); 
    }
}
