using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMovement playerMovement;

    private int previousScene;

    public float energy;

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

    private void Update()
    {
        energy -= Time.deltaTime;
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }


    void EnergyDepleted()
    {


    public void BehindPc()
    {
        playerMovement.isBehindPc = true;
    }
}
