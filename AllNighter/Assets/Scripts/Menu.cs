using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string lvlToStart;
    public GameObject controlsScreen, hubControls,codingControls,playtestControls;

    public void StartGame()
    {
        SceneManager.LoadScene(lvlToStart);
    }

    public void Controls()
    {
        controlsScreen.SetActive(true);
        hubControls.SetActive(true);
        codingControls.SetActive(false);
        playtestControls.SetActive(false);
    }

    public void CodingControls()
    {
        hubControls.SetActive(false);
        codingControls.SetActive(true);
        playtestControls.SetActive(false);
    }

    public void PlaytestControls()
    {
        hubControls.SetActive(false);
        codingControls.SetActive(false);
        playtestControls.SetActive(true);
    }


    public void EndGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        controlsScreen.SetActive(false);
        hubControls.SetActive(false);
        codingControls.SetActive(false);
        playtestControls.SetActive(false);
    }
}
