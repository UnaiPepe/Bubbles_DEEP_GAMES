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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        sm.ButtonClick();
    }

    public void QuitGame()
    {
        Debug.Log("You quitteded");
        Application.Quit();
    }
}