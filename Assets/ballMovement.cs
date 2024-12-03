using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ballMovement : MonoBehaviour
{
    //Ball Stats
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;

    private int scoreCounter;
    private Rigidbody2D _rb;

    //BallSpawn
    float randomX;
    float randomY;
    
    private void Start()
    {
        randomX = Random.Range(-0.1f, 0.1f);
        randomY = Random.Range(-0.1f, 0.1f);
        //Ensures randomX spawn pos cannot be 0
        if (randomX == 0)
        {
            while(randomX == 0)
            {
                randomX = Random.Range(-0.1f, 0.1f);
            }
        }
        //Ensures randomY spawn pos cannot be 0
        if(randomY == 0)
        {
            while (randomY == 0)
            {
                randomY = Random.Range(-0.1f, 0.1f);
            }
        }

        Invoke("SpawnBall", 2f);

        _rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(0, 0);
    }
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, initialSpeed + (speedIncrease * scoreCounter));
    }
    private void SpawnBall()
    {
        _rb.velocity = new Vector2(randomX, randomY) * (initialSpeed + speedIncrease * scoreCounter);
    }
    private void ResetBall()
    {
        _rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        Invoke("SpawnBall", 2f); //spawns ball after 2secs
    }

    private void Bounce()
    {

    }

}
