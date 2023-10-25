using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private const float JumpForce = 325;
    private const float MaxSpeed = 10;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {
            _rigidBody.AddForce (new Vector2(0f,JumpForce));
            isGrounded = false;
        }
        var horizontalDir = Input.GetAxis ("Horizontal");
        _rigidBody.velocity = new Vector2 (horizontalDir * MaxSpeed, _rigidBody.velocity.y);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
