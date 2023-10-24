using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands_sequence : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] bool buttonPress;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            buttonPress = true;
        }
        else
        {
            buttonPress = false;
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
