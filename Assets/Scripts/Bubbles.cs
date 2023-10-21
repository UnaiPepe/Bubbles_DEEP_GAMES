using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed = 1;
    public float wavyness = 0;

    public float spawnSpeed = 0.5f;
    public float spawnTimer = 0f;
    private float rarity;

    public char key;


    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        
        int indice = Random.Range(0, 26);
        key = (char)('A' + indice);
        Debug.Log("Letra aleatoria: " + key);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(wavyness, speed);

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnSpeed)
        {
            spawnTimer = 0f;
            Spawn();
        }
    }

    public void Spawn()
    {
        wavyness = Random.Range(-1f, 1f);
        //rarity = Random.Range(0f, 1f);

        //if (rarity < 0.5)
        //{
        //    wavyness = 0;
        //}

        //else if (rarity >= 0.5 && rarity < 0.75)
        //{
        //    wavyness = 1f;
        //}

        //else if (rarity >= 0.75)
        //{
        //    wavyness = -1f;
        //}
    }
}
