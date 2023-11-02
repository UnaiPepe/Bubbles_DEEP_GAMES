using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer_text;
    public soundManager sm;
    public float timer = 60;

    private void Start()
    {
        sm = FindObjectOfType<soundManager>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        int timer_rounded = Mathf.RoundToInt(timer);
        string timer_in_string = timer_rounded.ToString();
        timer_text.text = timer_in_string;

        if(timer <= 0)
        {
            timer = 0;
            sm.hands_animation_inhale.volume = 0;
            SceneManager.LoadScene("3_YouLost");
        }
    }
}
