using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBestTime : MonoBehaviour {
    public int minutes;
    public int seconds;
    public float milliseconds;

    public GameObject finalMinutesDisplay;
    public GameObject finalSecondsDisplay;
    public GameObject finalMillisecondsDisplay;

    void Start () {
        minutes = PlayerPrefs.GetInt("MinuteSave"); // get the name of the playerprefs from lap finish trigger script
        seconds = PlayerPrefs.GetInt("SecondsSave");
        milliseconds = PlayerPrefs.GetFloat("MillisecondsSave");

        // display the saved time to the screen
        finalMinutesDisplay.GetComponent<Text>().text = "" + minutes + ":";
        finalSecondsDisplay.GetComponent<Text>().text = "" + seconds + ".";
        finalMillisecondsDisplay.GetComponent<Text>().text = "" + milliseconds;
    }

}
