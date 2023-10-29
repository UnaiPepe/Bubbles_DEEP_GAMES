using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] bubbles;

    public float check_timer = 0f;
    public float check_cooldown = 0.25f;
    public bool can_press = false;

    public string key_pressed;

    public float size = 1f;
    public float rarity = 0.25f;

    //Progress Bar

    public float progress = 0.25f;

    public GameObject Bar;

    //Background 

    public SpriteRenderer white_background;
    private float new_alpha = 1f;

    // Music Background
    public AudioSource backgroundmusic; // Referencia al componente AudioSource.
    public float FadeOutSpeed = 0.5f;


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

        //Background changing color
        if(progress > 0.2f) //Original Alpha
        {
            Color colorActual = white_background.color;
            Color nuevoColor = new Color(colorActual.r, colorActual.g, colorActual.b, 255);
            white_background.color = nuevoColor;
            
        }

        if (progress > 0.05f && progress <= 0.2f) //First Alpha Reduction
        {
            Color colorActual = white_background.color;
            float nuevoAlpha = Mathf.Lerp(colorActual.a, 20, 1f * Time.deltaTime);
            Color nuevoColor = new Color(colorActual.r, colorActual.g, colorActual.b, nuevoAlpha);
            white_background.color = nuevoColor;
            Debug.Log("REDUCED ALPHA 1");
        }

        if (progress <= 0.05f) //Second Alpha Reduction
        {
            Color colorActual = white_background.color;
            float nuevoAlpha = Mathf.Lerp(colorActual.a, 0, 1f * Time.deltaTime);
            Color nuevoColor = new Color(colorActual.r, colorActual.g, colorActual.b, nuevoAlpha);
            white_background.color = nuevoColor;

            Debug.Log("REDUCED ALPHA 2");
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
                        size = 0.85f;

                        progress -= 0.1f;  //TWEAK AND PLAY WITH THIS. BASE WAS -= 0.15f;
                        if (progress <= 0)
                        {
                            progress = 0.05f;
                        }

                        else if (Bar.transform.localScale.x >= 1f) //IF PROGRESS BAR HAS REACHED 1 IN SCALE VALUE
                        {
                            
                            //LOAD WIN
                        }
                       
                        Grow();
                    }
                    else if (buble.GetComponent<Bubbles>().white == false)
                    {
                        progress += 0.05f;   //TWEAK AND PLAY WITH THIS. BASE WAS += 0.1f;
                        size = 1.1f;
                        rarity += 0.1f;
                    }
                    
                    Destroy(buble);
                }
            }
            buble.GetComponent<Bubbles>().UpdateSize();

        }
    }

    public void Grow()
    {

        Vector3 newScale = Bar.transform.localScale;
        newScale.x += progress;
        Bar.transform.localScale = newScale;
    }

    public void Change_Background()
    {

        if (progress <= 0.05f)
        {
            new_alpha = 0f;
        }
        else if (progress >= 0.05f && progress <= 0.2f)
        {
            new_alpha = 0.5f;
        }
        else if (progress >= 0.2f)
        {
            new_alpha = 1f;
        }

    }

    public void FindBubbles()
    {
        bubbles = GameObject.FindGameObjectsWithTag("Bubble");
    }

    void OnGUI()
    {
        if (can_press == true)
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

}
