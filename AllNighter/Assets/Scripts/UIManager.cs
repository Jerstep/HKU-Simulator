using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Text timeValueText;
    public Image energybar,progressbar;

    public float time = 300;
    bool gameIsRunning = true;

    private GameManager gameMan;
    private ObjectiveManager objectMan;
    private EndStats endStats;

    // Start is called before the first frame update
    void Start()
    {
        gameMan = GetComponent<GameManager>();
        objectMan = GetComponent<ObjectiveManager>();
        endStats = GameObject.Find("Resultholder").GetComponent<EndStats>();
    }

    // Update is called once per frame
    void Update()
    {

        string timemin = ((int)time / 60).ToString();
        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        energybar.fillAmount = gameMan.energy / 100;
        progressbar.fillAmount = objectMan.progress / 100;

        timeValueText.text = timemin + ":" + timeSeconds;

        if(time <= 0 && gameIsRunning)
        {
            toResults();
        }
    }

    void toResults()
    {
        endStats.GrabStatus();
    }
}
