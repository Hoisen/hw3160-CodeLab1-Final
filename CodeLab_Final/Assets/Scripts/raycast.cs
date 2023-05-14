using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class raycast : MonoBehaviour
{
    //Player Movement
    public CharacterController controller;
    public float speed = 12f;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGround;
    
    //Raycast
    private Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity + Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("world");
        }
        
        //Raycast Hit
        
        //ray = new Ray(transform.position, transform.forward);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 2, Color.blue);
        CheckIfHitted();

        if (transform.position.y < -45)
        {
            SceneManager.LoadScene("world");
        }
    }

    void CheckIfHitted()
    {
        if (Physics.Raycast(ray, out hit, 3))
        {
            Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color hitColor = renderer.material.color;
                Debug.Log(hit.collider.gameObject.name + hitColor);
                
            }
            Debug.Log(hit.collider.gameObject.name + " hitted!");
        }
    }

    void ColorToWorld()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Door")
        {
            int index = Random.Range(2, 5);
            //Debug.Log("Trans to scene: " + index);
            SceneManager.LoadScene(index);
        }

        if (other.tag == "first")
        {
            SceneManager.LoadScene("world");
        }

        if (other.tag == "pipe")
        {
            transform.position = new Vector3(-16, -3, -36);
        }

        if (other.tag == "start")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
