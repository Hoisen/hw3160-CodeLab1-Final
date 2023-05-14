using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow2d : MonoBehaviour
{
    public Transform cam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.transform.position;

        if (playerPos.x > 21)
        {
            cam.position = new Vector3(playerPos.x, playerPos.y, -10);
        }
        else if (playerPos.y < -3)
        {
            cam.position = new Vector3(playerPos.x, playerPos.y, -10);
        }
    }
}
