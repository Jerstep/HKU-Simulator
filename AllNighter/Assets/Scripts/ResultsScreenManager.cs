using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultsScreenManager : MonoBehaviour
{

    EndStats statsScript;

    public Text progressValue, RankValue;
    public float progress;


    // Start is called before the first frame update
    void Start()
    {
        progress = statsScript.progress;
        progressValue.text = progress + "%";
        if(progress < 25)
        {
            RankValue.text = "D";
        }
        else if (progress >= 25 && progress < 50)
        {
            RankValue.text = "C";
        }
        else if (progress >= 50 && progress < 75)
        {
            RankValue.text = "B";
        }
        else if (progress >= 75 && progress < 100)
        {
            RankValue.text = "A";
        }
        else if (progress >= 100)
        {
            RankValue.text = "S";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
