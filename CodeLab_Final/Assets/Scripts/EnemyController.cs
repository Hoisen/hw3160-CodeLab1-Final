using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-4.0f, 0);

        if(this.transform.position.x < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
