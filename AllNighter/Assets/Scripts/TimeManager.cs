using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int daycount;
    public float time = 300;
    public float timeScale = 1;

    //Rotation Angles for sun
    public float xAngle, yAngle, zAngle;

    public Text timeValueText, dayValueText;
    public Image energybar;
    public GameObject sun;


    PlayerStateManager playerState;

    // Start is called before the first frame update
    void Awake()
    {
        playerState = GetComponent<PlayerStateManager>();
    }

    void Update()
    {
        StartCoroutine(DayCycle());
        DisplayTime();
    }

    void DisplayTime()
    {
        dayValueText.text = "Day: " + daycount.ToString();

        string timemin = ((int)time / 60).ToString();
        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        energybar.fillAmount = playerState.energy / 100;
        timeValueText.text = timemin + ":" + timeSeconds;
    }

    IEnumerator DayCycle()
    {
        yield return new WaitForSeconds(timeScale);
        sun.transform.Rotate(xAngle, yAngle, zAngle);
    }
}
