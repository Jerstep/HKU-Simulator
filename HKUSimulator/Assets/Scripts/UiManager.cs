using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    private float time = 300;
    public Text timeText;
    private PlayerFlags player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFlags>();
    }

    // Update is called once per frame
    void Update()
    {
        string timemin = ((int)time / 60).ToString();

        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        timeText.text = timemin + ":" + timeSeconds;
    }
}
