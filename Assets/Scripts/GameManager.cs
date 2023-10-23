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


    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                Debug.Log(Event.current.keyCode);
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
                    Destroy(buble);
                }
            }
            
            
        }
    }




    public void Destroy_Key()
    {
        foreach(GameObject bubble in bubbles)
        {
            //bubble.gameObject.GetComponent<Bubbles>().key_to_press;
        }
    }

    private void shit_dump()
    {
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C))
        //{

        //}

        //foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKey(kcode))
        //        Debug.Log("KeyCode down: " + kcode);
        //}


        //for (char letra = 'A'; letra <= 'Z'; letra++)
        //{
        //    // Convierte el char a KeyCode (por ejemplo, 'A' a KeyCode.A).
        //    KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), letra.ToString());

        //    // Verifica si la tecla correspondiente ha sido presionada.
        //    if (Input.GetKeyDown(keyCode))
        //    {
        //        // Realiza acciones cuando el jugador pulsa una tecla del alfabeto.
        //        Debug.Log("¡El jugador ha pulsado la tecla " + letra + "!");
        //    }
        //}

        //// Itera a través de las letras desde 'A' hasta 'Z'.
        //for (char letra = 'A'; letra <= 'Z'; letra++)
        //{
        //    // Convierte el char a KeyCode (por ejemplo, 'A' a KeyCode.A).
        //    KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), letra.ToString());

        //    // Verifica si la tecla correspondiente ha sido presionada.
        //    if (Input.GetKeyDown(keyCode))
        //    {
        //        // Realiza acciones cuando el jugador pulsa una tecla del alfabeto.
        //        Debug.Log("¡El jugador ha pulsado la tecla " + letra + "!");
        //    }
        //}

    }


}
