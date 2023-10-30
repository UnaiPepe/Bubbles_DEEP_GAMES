using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Music Background
    public soundManager SoundManager;
    public AudioSource backgroundmusic; // Referencia al componente AudioSource.
    public float FadeOutSpeed = 0.5f;

    //Resting 

    public bool isResting = false;
    public float Time_to_rest = 5f;
    public float resting_timer = 0f;
    

    private void Start()
    {
        SoundManager = FindObjectOfType<soundManager>();
        //Color colorActual = white_background.color;
        //Color nuevoColor = new Color(colorActual.r, colorActual.g, colorActual.b, 120);
        //white_background.color = nuevoColor;
        white_background.color = new Color(white_background.color.r, white_background.color.g, white_background.color.b, 120);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Bar.transform.localScale.x >= 1f) //IF PROGRESS BAR HAS REACHED 1 IN SCALE VALUE
        {

            SceneManager.LoadScene("4_YouWon"); //LOAD WIN
        }

        if (can_press == false)
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
            Color nuevoColor = new Color(colorActual.r, colorActual.g, colorActual.b, 120);
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

        if(isResting)
        {
            resting_timer += Time.deltaTime;

            if (resting_timer >= 1f && resting_timer < 3f)
            {
                progress = 0.15f;
                size = 1.1f;
                SoundManager.game_soundrack.volume = Mathf.Lerp(SoundManager.game_soundrack.volume, 0.5f, 1f * Time.deltaTime);
            }

            if (resting_timer >= 3f)
            {
                progress = 0.25f;
                size = 1.25f;
                SoundManager.game_soundrack.volume = Mathf.Lerp(SoundManager.game_soundrack.volume, 1f, 1f * Time.deltaTime);
            }
        }


    }

   

    public void DestroyBubbles()
    {
        bool is_killed;

        is_killed = false;

        FindBubbles();

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
                        SoundManager.game_soundrack.volume = SoundManager.game_soundrack.volume * 0.75f;
                        progress -= 0.10f;  //TWEAK AND PLAY WITH THIS. BASE WAS -= 0.15f;
                        if (progress <= 0)
                        {
                            SoundManager.game_soundrack.volume = Mathf.Lerp(SoundManager.game_soundrack.volume, 0.1f, 0.5f * Time.deltaTime);
                            progress = 0.01f;
                        }

                        else if (Bar.transform.localScale.x >= 1f) //IF PROGRESS BAR HAS REACHED 1 IN SCALE VALUE
                        {
                            
                            SceneManager.LoadScene("4_YouWon"); //LOAD WIN
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

    //public void Change_Background()
    //{

    //    if (progress <= 0.05f)
    //    {
    //        new_alpha = 0f;
    //    }
    //    else if (progress >= 0.05f && progress <= 0.2f)
    //    {
    //        new_alpha = 0.5f;
    //    }
    //    else if (progress >= 0.2f)
    //    {
    //        new_alpha = 1f;
    //    }

    //}

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

    public void Resting()
    {
        isResting = true;
    }

}
