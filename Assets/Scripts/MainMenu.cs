using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int levelToLoad;
    public soundManager sm;

    private void Start()
    {
        sm = FindObjectOfType<soundManager>();
    }
    public void PlayGame(int levelIndex)
    {
        sm.hands_animation_inhale.volume = 1;
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