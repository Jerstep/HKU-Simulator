using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int daycount;
    public float time = 300;

    PlayerStateManager playerState;

    public Text timeValueText, dayValueText;

    public Image energybar;

    public static GameManager instance = null;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        playerState = GameObject.FindWithTag("Player").GetComponent<PlayerStateManager>();

       /* if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);*/        
    }

    // Update is called once per frame
    void Update()
    {
        dayValueText.text = "Day: " + daycount.ToString();
        


        string timemin = ((int)time / 60).ToString();

        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        energybar.fillAmount = playerState.energy / 100;
        timeValueText.text = timemin + ":" + timeSeconds;
    }
}
