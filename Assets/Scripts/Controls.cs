using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public GameObject PlayerControls;
    public GameObject AiControls;

    void Start () {
        PlayerControls.GetComponent<UFOEngine>().enabled = true;
        AiControls.GetComponent<AI_Engine>().enabled = true;

    }
	
}
