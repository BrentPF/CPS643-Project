using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TextMeshPro finishTime;
    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    public GameObject gate4;
    public bool puzzle1 = false;
    public bool puzzle2 = false;
    public bool puzzle3 = false;
    public bool puzzle4 = false;
    private float timeValue = 0;
    private float minutes = 0;
    private float seconds = 0;
    private float hours = 0;
    private string secondsText;
    private string minutesText;
    private string hoursText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeValue += Time.deltaTime;
        if (puzzle1) {
            gate1.GetComponent<Gate>().open();
            puzzle1 = false;
        }
        if (puzzle2)
        {
            gate2.GetComponent<Gate>().open();
            puzzle2 = false;
        }
        if (puzzle3)
        {
            gate3.GetComponent<Gate>().open();
            puzzle3 = false;
        }
        if (puzzle4)
        {
            gate4.GetComponent<Gate>().open();
            displayTime();
            puzzle4 = false;
        }
    }

    void displayTime()
    {

        minutes = Mathf.Floor(timeValue / 60);
        seconds = Mathf.RoundToInt(timeValue % 60);
        hours = Mathf.Floor(timeValue / 3600);
        if (minutes < 10)
        {
            minutesText = "0" + minutes.ToString();
        }
        else
        {
            minutesText = minutes.ToString();
        }
        if (seconds < 10)
        {
            secondsText = "0" + Mathf.RoundToInt(seconds).ToString();
        }
        else
        {
            secondsText = Mathf.RoundToInt(seconds).ToString();
        }
        if (hours < 10)
        {
            hoursText = "0" + Mathf.RoundToInt(hours).ToString();
        }
        else
        {
            hoursText = Mathf.RoundToInt(hours).ToString();
        }
        finishTime.text = hoursText + ":" + minutesText + ":" + secondsText;
        
    }

    public void restart() {
        SceneManager.LoadScene("Game");
    }
}
