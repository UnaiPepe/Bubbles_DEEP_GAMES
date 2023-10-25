using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] bubbles;

    public float check_timer = 0f;
    public float check_cooldown = 1f;
    public bool can_press = false;

    public string key_pressed;

    public float size = 1f;
    public float rarity = 0.25f;

    //Progress Bar

    public float progress = 0f;

    public GameObject Bar;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(can_press == false)
        {
            check_timer += Time.deltaTime;
            can_press = false;
        }


        if (check_timer >= check_cooldown)
        {
            check_timer = 0f;
            can_press = true;
        }

    }

    public void FindBubbles()
    {
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
    }

    void OnGUI()
    {
        if(can_press == true)
        {
            if (Event.current.isKey && Event.current.type == EventType.KeyDown)
            {
                //Debug.Log(Event.current.keyCode);
                key_pressed = Event.current.keyCode.ToString();
                can_press = false;
                DestroyBubbles();
            }
        }
        
    }

    public void DestroyBubbles()
    {
        bool is_killed;

        is_killed = false;

        foreach (GameObject buble in bubbles)
        {
            string key_from_bubble;
            key_from_bubble = buble.GetComponent<Bubbles>().key.ToString();

            if(is_killed == false)
            {
                if (key_from_bubble == key_pressed)
                {
                    is_killed = true;
                    if(buble.GetComponent<Bubbles>().white == true)
                    {
                        size -= 0.25f;

                        progress -= 0.25f;
                        if(progress <= 0)
                        {
                            progress = 0.1f;
                        }

                        else if (progress == 1f)
                        {
                            //LOAD WIN
                        }

                        Grow();
                    }
                    else if (buble.GetComponent<Bubbles>().white == false)
                    {
                        progress += 0.15f;
                        size += 0.15f;
                        rarity += 0.1f;
                    }
                    
                    Destroy(buble);
                }
            }
            
            
        }
    }

    public void Grow()
    {

        Vector3 newScale = Bar.transform.localScale;
        newScale.x = progress;
        Bar.transform.localScale = newScale;
    }


}
