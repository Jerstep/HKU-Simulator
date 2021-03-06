﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmGameManager : MonoBehaviour
{

    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static RhythmGameManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;

    public Text scoreText,multiText;

    public float totalNotes;
    public float normalHits, goodHits, perfectHits, missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalText, goodText, perfectText, missesText, rankText, finalScoreText;

    GameManager gameMan;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: " + 0;
        currentMultiplier = 1;
        gameMan = GameObject.Find("GameManager").GetComponent <GameManager>();
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                normalText.text = normalHits.ToString();
                goodText.text = goodHits.ToString();
                perfectText.text = perfectHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if(percentHit > 40)
                {
                    rankVal = "D";
                    if(percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 99)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        if(currentMultiplier - 1 < multiplierThreshold.Length)
        {
            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x: " + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit(bool isEnergy)
    {
        if (isEnergy)
        {
            gameMan.energy += 5;
        }
        currentScore += scorePerNote * currentMultiplier;
        normalHits++;
        NoteHit();
    }

    public void GoodHit(bool isEnergy)
    {
        if (isEnergy)
        {
            gameMan.energy += 10;
        }
        currentScore += scorePerGoodNote * currentMultiplier;
        goodHits++;
        NoteHit();
    }

    public void PerfectHit(bool isEnergy)
    {
        if (isEnergy)
        {
            gameMan.energy += 20;
        }
        currentScore += scorePerPerfectNote * currentMultiplier;
        perfectHits++;
        NoteHit();
    }


    public void NoteMiss()
    {
        Debug.Log("Miss");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x: " + currentMultiplier;
        missedHits++;
    }
}
