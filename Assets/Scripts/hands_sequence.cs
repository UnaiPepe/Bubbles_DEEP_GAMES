using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_sequence : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool buttonPress;

    public GameObject GameManager;
    public soundManager sm;
    public Canvas canvas_UI;
    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
        sm = FindObjectOfType<soundManager>();
        sm.Brown_Noise();
        sm.hands_brown_noise.volume = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            sm.HandsAnimationExhale(); 
            // for some reason it works exactly the opposite way from how it should
            // and I spent two hours trying to understand that.
            // I didn't. I do now know there can never be enough audiosources
            buttonPress = true;
            GameManager.GetComponent<GameManager>().isResting = true;
            canvas_UI.GetComponent<Canvas>().enabled = false;
            
            
        }
        else
        {   
            // ^^^^^^^^^^^^^^^
            sm.HandsAnimationInhale(); 
            buttonPress = false;
            GameManager.GetComponent<GameManager>().isResting = false;
            GameManager.GetComponent<GameManager>().resting_timer = 0f;
            canvas_UI.GetComponent<Canvas>().enabled = true;

        }

        if (buttonPress == true)
        {
            anim.SetBool("animGo", true);
            
            
            if (sm.hands_brown_noise.volume != 0.5f)
            {
                sm.hands_brown_noise.volume = Mathf.Lerp(sm.hands_brown_noise.volume, 0.5f, 2f * Time.deltaTime);
            }
        }
        else
        {
            if (sm.hands_brown_noise.volume != 0)
            {
                sm.hands_brown_noise.volume = Mathf.Lerp(sm.hands_brown_noise.volume, 0f, 2f * Time.deltaTime);
            }
            anim.SetBool("animGo", false);
        }
    }
}
