using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int previousScene;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void OnClickLoadSceneButton(int sceneIndex)
    {
        previousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
}
