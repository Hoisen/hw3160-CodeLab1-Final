using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class raycast : MonoBehaviour
{
    //Player Movement
    public CharacterController controller;
    public float speed = 12f;
    
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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        
        //Raycast Hit
        
        //ray = new Ray(transform.position, transform.forward);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 2, Color.blue);
        CheckIfHitted();
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }

        if (other.tag == "first")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("world");
        }
    }
}
