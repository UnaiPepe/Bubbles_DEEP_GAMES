using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public soundManager sm;

    private void Start()
    {
        sm = FindObjectOfType<soundManager>();
    }
    public void PlayGame(int levelIndex)
    {
        sm.hands_animation_inhale.volume = 1;
        sm.ButtonClick();
        SceneManager.LoadScene("2_Tutorial");
    }   

    public void QuitGame()
    {
        sm.ButtonClick();
        Debug.Log("You quitteded");
        Application.Quit();
    }

    public void RetryGame()
    {
        sm.ButtonClick();
        sm.game_soundrack.volume = 1f;
        SceneManager.LoadScene("2_Tutorial");
    }
}