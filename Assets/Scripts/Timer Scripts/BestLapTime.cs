using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestLapTime : MonoBehaviour {
    public int minutes;
    public int seconds;
    public float milliseconds;

    public GameObject minutesDisplay;
    public GameObject secondsDisplay;
    public GameObject millisecondsDisplay;

    void Start () {
        minutes = PlayerPrefs.GetInt("MinuteSave"); // get the name of the playerprefs from lap finish trigger script
        seconds = PlayerPrefs.GetInt("SecondsSave");
        milliseconds = PlayerPrefs.GetFloat("MillisecondsSave");

        // display the saved time to the screen
        minutesDisplay.GetComponent<Text>().text = "" + minutes + ":";
        secondsDisplay.GetComponent<Text>().text = "" + seconds + ".";
        millisecondsDisplay.GetComponent<Text>().text = "" + milliseconds;
    }

}
