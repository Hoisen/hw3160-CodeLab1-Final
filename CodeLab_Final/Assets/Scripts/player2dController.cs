using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2dController : MonoBehaviour
{
bool jump = false;
    bool canJump = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * 0.05f, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * 0.05f, ForceMode2D.Impulse);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)&& canJump)
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("worldTwo");
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("world");
        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            canJump = false;
            jump = false;
            rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Floor")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "first")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("world");
        }

        if (col.tag == "Final")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("End");
        }
    }
}
