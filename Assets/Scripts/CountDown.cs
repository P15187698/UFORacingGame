using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    public GameObject countdown;
    public AudioSource GetReady;
    public AudioSource Go;
    public GameObject LapTimer;
    public GameObject Controls;

    void Start () {
        StartCoroutine(CountStart());
	}

    IEnumerator CountStart ()
    {
        yield return new WaitForSeconds(0.5f); // wait for half a second before starting countdown
        countdown.GetComponent<Text>().text = "3"; //in case ui text doesnt appear i have set it to here
        GetReady.Play(); //play first beep sound effect
        countdown.SetActive(true);
        yield return new WaitForSeconds(1); //wait for 1 second whilst sound is playing as this is how long animation takes
        countdown.SetActive(false); //once animation is played the number 3 disappears

        countdown.GetComponent<Text>().text = "2"; //countdown text now becomes a 2
        GetReady.Play(); //beep sound effect is played again
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);

        countdown.GetComponent<Text>().text = "1";
        GetReady.Play();
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);

        countdown.GetComponent<Text>().text = "GO!";
        Go.Play(); //final sound effect plays to signal go
        countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        countdown.SetActive(false);

        LapTimer.SetActive(true); //lap timer starts after countdown
        Controls.SetActive(true); //ai and player can now start driving
    }
}
