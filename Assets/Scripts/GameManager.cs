using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] bubbles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C))
        {

        }
    }

    public void FindBubbles()
    {
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
    }

    

    public void Destroy_Key()
    {
        foreach(GameObject bubble in bubbles)
        {
            //bubble.gameObject.GetComponent<Bubbles>().key_to_press;
        }
    }
}
