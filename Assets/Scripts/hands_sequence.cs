using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_sequence : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool buttonPress;

    public GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            buttonPress = true;
            GameManager.GetComponent<GameManager>().isResting = true;
        }
        else
        {
            buttonPress = false;
            GameManager.GetComponent<GameManager>().isResting = false;
            GameManager.GetComponent<GameManager>().resting_timer = 0f;


        }

        if (buttonPress == true)
        {

            anim.SetBool("animGo", true);
        }
        else
        {
            anim.SetBool("animGo", false);
        }
    }
}
