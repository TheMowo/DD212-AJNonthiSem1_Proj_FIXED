using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private GameObject _paddle;
    private float _timer = 0f;
    private bool isPressing = false;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMovement = Input.GetAxisRaw("Horizontal");
        float VerticalMovement = Input.GetAxisRaw("Vertical");
        _rb.velocity = new Vector2(HorizontalMovement * _movementSpeed, VerticalMovement * _movementSpeed);
        Paddle();
        Hit();
        
    }
    private void Paddle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, 0, 45);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 0, -45);
        }
    }

    private void Hit()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPressing)
        {
            _paddle.GetComponent<BoxCollider2D>().enabled = true;
            isPressing = true; 
            _timer = 0f;
        }
      
        if (isPressing) 
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                _paddle.GetComponent<BoxCollider2D>().enabled = false;
                isPressing = false;
            }
        }
    }
}
