using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStats : MonoBehaviour
{
    public float progress;

    private static bool statsExists;

    ObjectiveManager objectiveMan;
    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        if (!statsExists)
        {
            statsExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void GrabStatus()
    {
        objectiveMan = GameObject.Find("GameManager").GetComponent<ObjectiveManager>();
        progress = objectiveMan.progress;

        SceneManager.LoadScene(sceneToLoad);
    }
}
