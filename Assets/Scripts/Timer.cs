using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer_text;

    public float timer = 60;

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
            SceneManager.LoadScene("3_YouLost");
        }
    }
}
