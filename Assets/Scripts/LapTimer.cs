using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour {
    //variables for time passed on the lap
    public static int minutes; //static allows you to reference the variable in a different script
    public static int seconds;
    public static float milliseconds;
    public static string milliDisplay;

    public GameObject minuteUI;
    public GameObject secondUI;
    public GameObject milliUI;

	// Update is called once per frame
	void Update () {
        milliseconds += Time.deltaTime * 10; //takes the milliseconds and adds the time every frame
        milliDisplay = milliseconds.ToString ("F0"); //converted the milliseconds timer into a string to be displayed in a text box

        //use GetComponent to refer to the component of the canvas which is the text
        milliUI.GetComponent<Text>().text = "" + milliDisplay; //this adds the milliseconds string to the box on the game's canvas

        //milliseconds needs to go back to 0 so it can recount to 10
        if(milliseconds >= 10) {
            milliseconds = 0; //resets the milliseconds to 0;
            seconds += 1; //once milliseconds reaches 10, 1 second has passed in game so it adds this on
        }

        if(seconds <= 9){
            secondUI.GetComponent<Text>().text = "0" + seconds + "."; 
        }
        else {
            secondUI.GetComponent<Text>().text = "" + seconds + "."; //if seconds is greater than 9 then it is a double digit number so remove the 0
        }

        //if seconds count becomes 60 then a minute needs to be added on
        if(seconds >= 60){
            seconds = 0; //resets the seconds counter to 0
            minutes += 1; //adds a minute onto the timer
        }

        if (minutes <= 9)
        {
            minuteUI.GetComponent<Text>().text = "0" + minutes + ".";
        }
        else
        {
            minuteUI.GetComponent<Text>().text = "" + minutes + ".";
        }
    }
}
