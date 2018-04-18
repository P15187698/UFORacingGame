using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapComplete : MonoBehaviour {

    public GameObject lapCompleteTrigger;
    public GameObject checkpointTrigger;

    // best time variables
    public GameObject minutesBest;
    public GameObject secondsBest;
    public GameObject millisecondsBest;

    public static float milliBest;
    public static string milliBestDisplay;

    public GameObject lapCounter;
    public static int lapsCompleted = 0;

    public float bestTime;
    public int requiredLaps; // set in the unity editor so I can change number of laps required for each track without hardcoding them

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player") // using tags so that the ai doesn't trigger the same lap count as the player
        {
            // adds 1 to the laps completed counter
            // it is triggered when player goes through the finish line trigger
            lapsCompleted += 1;

            if(lapsCompleted == requiredLaps) // if the player has completed the required amount of laps then carry out the following
            {
                GameMenu.gameFinished = true; // the game menu's gameFinished boolean will be triggered
            }

            bestTime = PlayerPrefs.GetFloat("Time"); // retrieve the stored best time from the playerprefs set after each lap

            // if lap timer's time is less than or equal to the time saved in this script
            // then do the following if statements for lap time
            // otherwise, set the playerprefs and reset the lap timer to 0 and carry on
            if (LapTimer.time <= bestTime)
            {
                // text display for best time, if seconds become greater than 9 then seconds text is set back to 0
                // a minute will be then added on
                if (LapTimer.seconds <= 9)
                {
                    secondsBest.GetComponent<Text>().text = "0" + LapTimer.seconds + "."; // if the seconds is greater than 9 then reset the text to 0
                }
                else
                {
                    secondsBest.GetComponent<Text>().text = "" + LapTimer.seconds + "."; // if the text has been set to 0 then simply display the current seconds here
                }

                // this is the same as seconds for the minute text
                if (LapTimer.minutes <= 9)
                {
                    minutesBest.GetComponent<Text>().text = "0" + LapTimer.minutes + ":";
                }
                else
                {
                    minutesBest.GetComponent<Text>().text = "" + LapTimer.minutes + ":";
                }

                // do not need to add a full stop as the milliseconds do not have a decimal place  
                millisecondsBest.GetComponent<Text>().text = "" + LapTimer.milliseconds;
            }

            //player prefs are written to when player crosses the finish line, will return to 0 after this
            PlayerPrefs.SetInt("MinuteSave", LapTimer.minutes); //saves the minutes time similar to saving a file
            PlayerPrefs.SetInt("SecondsSave", LapTimer.seconds); //saves the seconds time
            PlayerPrefs.SetFloat("MillisecondsSave", LapTimer.milliseconds); //saves the milliseconds


            // sets saved time, will only do this if the time is less than the previous time
            // this stops the time from being over written if it was slower than the previously saved one
            PlayerPrefs.SetFloat("Time", LapTimer.time);

            LapTimer.time = 0; // set the saved time back to 0

            // reset the time on the lap timer script back to 0 once best time has been triggered
            LapTimer.minutes = 0;
            LapTimer.seconds = 0;
            LapTimer.milliseconds = 0;

            // this always displays 0 so needs to be triggered
            lapCounter.GetComponent<Text>().text = "" + lapsCompleted;

            // set the checkpoint back to true so player can see it again after going through the finish line
            // this will be used so the track can have multiple laps
            checkpointTrigger.SetActive(true);
            lapCompleteTrigger.SetActive(false);
        }
    }
}
