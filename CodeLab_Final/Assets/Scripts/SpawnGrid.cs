using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;


public class SpawnGrid : MonoBehaviour
{
    public GameObject cube;
    public int gridX;
    public int gridZ;
    public int gridY;
    
    //
    //public GameObject leafCube;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public Vector3 positionRandomization;
    
    //Color
    public MeshRenderer[] renderers;
    float minHue = 0f;
    float maxHue = 1f;

    //Slider slider;
    //New Color - Random
    Color[] colors = new Color[6];

    // Start is called before the first frame update
    void Start()
    {
        //spawnGrid();
        SpawnDoor();
        // Color newColor = Random.ColorHSV(0f, 1f, 0.7f, 1f, .5f, 1);
        // ApplyMaterial(newColor, 0);
        //slider = gameObject.GetComponent<Slider>();
        colors[0] = Color.cyan;
        colors[1] = Color.black;
        colors[2] = Color.gray;
        colors[3] = Color.blue;
        colors[4] = Color.yellow;
        colors[5] = Color.magenta;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
    void SpawnDoor()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                for (int z = 0; z < gridZ; z++)
                {
                    Vector3 spawnPosition =
                        new Vector3(x * gridSpacingOffset, y * gridSpacingOffset,  z * gridSpacingOffset) + gridOrigin;
                    PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
                    Color newColor = Random.ColorHSV(0, 1, 0.5f, .7f, .5f, .8f);
                    //Color newColor = colors[Random.Range(0, colors.Length)];
                    ApplyMaterial(newColor, 0);
                }

            }
        }
    }
    
    // void spawnGrid()
    // {
    //     int randmod=0;
    //     randmod = Random.Range(0, 5);
    //
    //     //Spawn basic Tulip shape
    //     for (int x = 0; x < gridX; x++)
    //     {
    //         for (int z = 0; z < gridZ; z++)
    //         {
    //             Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
    //             PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
    //             Color newColor = Random.ColorHSV(0.2f *randmod, 0.2f *randmod+0.2f, 0.5f, .7f, .5f, .8f);
    //             ApplyMaterial(newColor, 0);
    //         }
    //     }
    //
    //     for (int x = 1; x < 8; x++)
    //     {
    //         for (int z = 0; z < 1; z++)
    //         {
    //             Vector3 secondPosition = new Vector3(x, 0, z-1);
    //             Vector3 thirdPos = new Vector3(x, 0, z + 6);
    //             PickAndSpawn(secondPosition, Quaternion.identity);
    //             PickAndSpawn(thirdPos, Quaternion.identity);
    //         
    //             Color newColor = Random.ColorHSV(0.2f *randmod, 0.2f *randmod+0.2f, 0.5f, .7f, .5f, .8f);
    //             ApplyMaterial(newColor, 0);
    //             // if (Input.GetKeyDown(KeyCode.Space))
    //             // {
    //             //     newColor = Random.ColorHSV(minHue + 0.2f, maxHue -0.2f);
    //             //     ApplyMaterial(newColor, 0);
    //             // }
    //         }
    //
    //     }
    //
    //     for (int x = 2; x < 7; x++)
    //     {
    //         for (int z = 0; z < 1; z++)
    //         {
    //             Vector3 fouthPos = new Vector3(x, 0, z - 2);
    //             Vector3 fifthPos = new Vector3(x, 0, z + 7);
    //             PickAndSpawn(fouthPos, Quaternion.identity);
    //             PickAndSpawn(fifthPos, Quaternion.identity);
    //             Color newColor = Random.ColorHSV(0.2f *randmod, 0.2f *randmod+0.2f, 0.5f, .7f, .5f, .8f);
    //             ApplyMaterial(newColor, 0);
    //             Debug.Log("randmod"+ randmod);
    //         }
    //     }
    //     
    //     //stem
    //     for (int x = 4; x < 5; x++)
    //     {
    //         for (int z = 8; z < 16; z++)
    //         {
    //             Vector3 stemsPos = new Vector3(x, 0, z);
    //             leafCubeSpawn(stemsPos, Quaternion.identity);
    //             // m_Hue = Random.Range(90, 180);
    //             // m_Sat = Random.Range(0, 100);
    //             // m_Val = Random.Range(0, 100);
    //             // //Color newColor = Color.HSVToRGB(m_Hue/360, m_Sat, m_Val);
    //             Color newColor = Random.ColorHSV(0.15f, .3f, .5f, 1f, 0.5f, 1);
    //             ApplyMaterial(newColor, 0);
    //         }
    //     }
    //     
    //     //leaf
    //     for (int x = 5; x < 7; x++)
    //     {
    //         for (int z = 0; z < 2; z++)
    //         {
    //             Vector3 leafPos = new Vector3(x, 0, z + 10);
    //             Vector3 secLeafPos = new Vector3(x + 1, 0, z + 9);
    //             leafCubeSpawn(leafPos, Quaternion.identity);
    //             leafCubeSpawn(secLeafPos, Quaternion.identity);
    //             Color newColor = Random.ColorHSV(0.15f, .3f, .5f, 1f, .5f, 1);
    //             ApplyMaterial(newColor, 0);
    //         }
    //     }
    //
    // }
    
    Vector3 RandomizedPosition(Vector3 position)
    {
        Vector3 randomizedPosition = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x), Random.Range(-positionRandomization.y, positionRandomization.y), Random.Range(-positionRandomization.z, positionRandomization.z)) + position;

        return randomizedPosition;

    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        //int randomIndex = Random.Range(0, cube.Length);
        GameObject clone = Instantiate(cube, positionToSpawn, rotationToSpawn);
    }

    // void leafCubeSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    // {
    //     GameObject leafClone = Instantiate(leafCube, positionToSpawn, rotationToSpawn);
    // }
    
    void ApplyMaterial(Color color, int targetMaterialIndex)
    {
        Material generatedMaterial = new Material(Shader.Find("Standard"));
        generatedMaterial.SetColor("_Color", color);
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = generatedMaterial;
        }
    }
}
