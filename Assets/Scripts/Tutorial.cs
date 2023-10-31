using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public soundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<soundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            sm.ButtonClick();
            SceneManager.LoadScene("1_Game");
        }

    }
}
