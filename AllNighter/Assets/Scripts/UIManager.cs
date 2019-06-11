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

    private GameManager gameManager;
    private ObjectiveManager objectMan;
    private EndStats endStats;

    [Space]

    [Header("Minigame Cameras for render to texture")]
    public Camera platformerCam1;
    public Camera platformerCam2;
    public Camera platformerCam3;
    public Camera RythemGameCam1;
    public Camera RythemGameCam2;

    [Space]

    [Header("Prefabs cooresponding to cameras")]
    public GameObject platformerPrefab1;
    public GameObject platformerPrefab2;
    public GameObject platformerPrefab3;
    public GameObject RythemGamePrefab1;
    public GameObject RythemGamePrefab2;

    public GameObject renderToTextureImage;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        objectMan = GetComponent<ObjectiveManager>();
        endStats = GameObject.Find("Resultholder").GetComponent<EndStats>();
    }

    // Update is called once per frame
    void Update()
    {

        string timemin = ((int)time / 60).ToString();
        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        energybar.fillAmount = gameManager.energy / 100;
        progressbar.fillAmount = objectMan.progress / 100;
        Debug.Log("Progress Bar" + progressbar.fillAmount);

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

    //#region Objective UI;
    //public void OnButtonPress(Objective objective)
    //{
    //    renderToTextureImage.SetActive(true);
    //    Debug.Log(objective.GetName());
    //    // Check on button press what game to activate.
    //    // Button gives an objective with an ID
    //    if(objective.GetName() == "platformer1")
    //    {
    //        Debug.Log("Platformer 1");
    //        platformerCam1.transform.gameObject.SetActive(true);
    //        platformerPrefab1.SetActive(true);
    //    }

    //    if(objective.objectiveID == "platformer2")
    //    {
    //        platformerCam2.transform.gameObject.SetActive(true);
    //        platformerPrefab2.SetActive(true);
    //    }

    //    if(objective.objectiveID == "platformer3")
    //    {
    //        platformerCam3.transform.gameObject.SetActive(true);
    //        platformerPrefab3.SetActive(true);
    //    }

    //    if(objective.objectiveID == "RhythmGame1")
    //    {
    //        RythemGameCam1.transform.gameObject.SetActive(true);
    //        RythemGamePrefab1.SetActive(true);
    //    }

    //    if(objective.objectiveID == "RhythmGame2")
    //    {
    //        RythemGameCam2.transform.gameObject.SetActive(true);
    //        RythemGamePrefab2.SetActive(true);
    //    }
    //}

    //public void SetMinigamesFalse()
    //{
    //    platformerCam1.transform.gameObject.SetActive(false);
    //    platformerPrefab1.SetActive(false);

    //    platformerCam2.transform.gameObject.SetActive(false);
    //    platformerPrefab2.SetActive(false);

    //    platformerCam3.transform.gameObject.SetActive(false);
    //    platformerPrefab3.SetActive(false);

    //    RythemGameCam1.transform.gameObject.SetActive(false);
    //    RythemGamePrefab1.SetActive(false);

    //    RythemGameCam2.transform.gameObject.SetActive(false);
    //    RythemGamePrefab2.SetActive(false);

    //    renderToTextureImage.SetActive(false);
    //}
    //#endregion 
    
    #region Objective UI;
    public void OnButtonPress(string objective)
    {
        renderToTextureImage.SetActive(true);
        Debug.Log(objective);
        // Check on button press what game to activate.
        // Button gives an objective with an ID
        if(objective == "platformer1")
        {
            Debug.Log("Platformer 1");
            platformerCam1.transform.gameObject.SetActive(true);
            platformerPrefab1.SetActive(true);
        }

        if(objective == "platformer2")
        {
            platformerCam2.transform.gameObject.SetActive(true);
            platformerPrefab2.SetActive(true);
        }

        if(objective == "platformer3")
        {
            platformerCam3.transform.gameObject.SetActive(true);
            platformerPrefab3.SetActive(true);
        }

        if(objective == "RhythmGame1")
        {
            RythemGameCam1.transform.gameObject.SetActive(true);
            RythemGamePrefab1.SetActive(true);
        }

        if(objective == "RhythmGame2")
        {
            RythemGameCam2.transform.gameObject.SetActive(true);
            RythemGamePrefab2.SetActive(true);
        }
    }

    public void SetMinigamesFalse()
    {
        platformerCam1.transform.gameObject.SetActive(false);
        platformerPrefab1.SetActive(false);

        platformerCam2.transform.gameObject.SetActive(false);
        platformerPrefab2.SetActive(false);

        platformerCam3.transform.gameObject.SetActive(false);
        platformerPrefab3.SetActive(false);

        RythemGameCam1.transform.gameObject.SetActive(false);
        RythemGamePrefab1.SetActive(false);

        RythemGameCam2.transform.gameObject.SetActive(false);
        RythemGamePrefab2.SetActive(false);

        renderToTextureImage.SetActive(false);
    }
    #endregion
}
