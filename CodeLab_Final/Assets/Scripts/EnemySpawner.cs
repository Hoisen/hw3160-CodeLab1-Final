using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;

    float spawnTime = 0.0f;


    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;

        if (spawnTime <= 0)
        {
            //Quaternion.LookRotation
            Instantiate(Enemy, this.transform.position, this.transform.rotation);
            spawnTime = Random.Range(0.0f, 2.0f);//2f;
        }

    }
}
