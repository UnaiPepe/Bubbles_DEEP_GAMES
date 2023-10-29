using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bubbles : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed = 10;
    public float wavyness = 0;

    public float spawnSpeed = 0.5f;
    public float spawnTimer = 0f;

    public char key;

    public TextMeshProUGUI key_to_press;
    public GameManager gameManager;
    public bool white;

    public bool ChangeSize = false;


    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        gameManager.FindBubbles();

        if(white)
        {
            this.gameObject.transform.localScale = this.gameObject.transform.localScale * gameManager.size;
        }

        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        
        int indice = Random.Range(0, 26);
        key = (char)('A' + indice);
        //Debug.Log("Letra aleatoria: " + key);
        string key_string = key.ToString();
        key_to_press.text = key_string;

       
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(wavyness, speed);

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnSpeed)
        {
            spawnTimer = 0f;
            Move();
        }

        if (white && ChangeSize)
        {
            Debug.Log("Smaller");
            this.gameObject.transform.localScale = new Vector3(Mathf.Lerp(this.gameObject.transform.localScale.x, (this.gameObject.transform.localScale.x * gameManager.size), 1f * Time.deltaTime), Mathf.Lerp(this.gameObject.transform.localScale.y, (this.gameObject.transform.localScale.y * gameManager.size), 1f * Time.deltaTime), this.gameObject.transform.localScale.z);
            ChangeSize = false;
            //this.gameObject.transform.localScale = this.gameObject.transform.localScale * gameManager.size;
        }

        
    }

    

    public void Move()
    {
        wavyness = Random.Range(-1f, 1f);
       
    }

    public void UpdateSize()
    {
        ChangeSize = true;
       
    }

    
}
