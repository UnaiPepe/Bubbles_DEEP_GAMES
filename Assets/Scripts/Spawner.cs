using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bubble;
    public GameObject black_bubble;

    private GameObject gameManager;

    public Collider2D area;
    public float spawnSpeed = 1f;
    public float spawnTimer = 0f;
    


    public void Start()
    {
        gameManager = GameObject.Find("GameManager");

        area = this.GetComponent<Collider2D>();

    }
    public void FixedUpdate()
    {

        spawnTimer += Time.deltaTime;


        if (spawnTimer >= spawnSpeed)
        {
            spawnTimer = 0f;
            Spawn();
        }

    }

    public void Spawn()
    {

        float randomX = Random.Range(area.bounds.min.x, area.bounds.max.x);
        float randomY = Random.Range(area.bounds.min.y, area.bounds.max.y);

        Vector2 spawnPosition = new Vector2(randomX, randomY);
        float random= Random.Range(0f, 1f);

        if (random < 1 - gameManager.GetComponent<GameManager>().rarity)
        {
            Instantiate(bubble, spawnPosition, Quaternion.identity);

        }

        else if (random >= 1 - gameManager.GetComponent<GameManager>().rarity)

        {
            Instantiate(black_bubble, spawnPosition, Quaternion.identity);
        }
    }
}
