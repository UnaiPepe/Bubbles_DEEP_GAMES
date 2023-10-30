using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int levelToLoad;
    public soundManager sm;

    public void PlayGame(int levelIndex)
    {
        
        SceneManager.LoadScene("2_Tutorial");
        sm.ButtonClick();
    }   

    public void QuitGame()
    {
        Debug.Log("You quitteded");
        Application.Quit();
    }

    public void RetryGame()
    {
        
        SceneManager.LoadScene("2_Tutorial");
    }
}