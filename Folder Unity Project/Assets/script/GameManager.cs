using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelCompleteUi; 

    public GameObject playAgain;
    
    public void EndGame()
    {
        Invoke("Restart", 2f);
    }


    public void Restart()
    {
        Debug.Log("UI Die");
        playAgain.SetActive(true);
    }

    public void LevelComplete()
    {
        levelCompleteUi.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("FINISHHHHHHHHHHHHHHHHHHHHHHHHH");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void MenuPlay()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play Success");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Success");
    }
}
