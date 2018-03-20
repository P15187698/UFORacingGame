using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {
    public GameObject LapFinishTrig;
    public GameObject CheckPointTrig;

    void OnTriggerEnter (){
        CheckPointTrig.SetActive(true);
        LapFinishTrig.SetActive(false);
    }
}
