using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    //text
    public TextMeshPro canvasText;
    public TextMeshPro hintText;

    private string sceneName;
    
    void Awake()
    {

        if (Instance == null) //Instance has not been set
        {
            DontDestroyOnLoad(gameObject); //dont destroy
            Instance = this; //and set instance to this GameManager
        }
        else //Instance is set
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Scene currentScene = SceneManager.GetActiveScene();
        // sceneName = currentScene.name;
        // Debug.Log(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(sceneName);
        if (sceneName == "SampleScene")
        {
            canvasText.text = "Only one door to escape from this infinite world";
        }

        else if (sceneName == "world")
        {
            canvasText.color = Color.gray;
            hintText.color = Color.gray;
            canvasText.text = "Choose one"+"\n"+"and step into the door";
            hintText.text = "R to restart";
        }

        else if (sceneName == "End")
        {
            canvasText.color = Color.black;
            canvasText.transform.position = new Vector3(-39, 2, -30);
            canvasText.text = "Congraz!" + "\n" + "Now enjoy the world";
        }
        
        else if (sceneName == "worldThree")
        {
            canvasText.transform.position = new Vector3(-9f, 17, -15);
            canvasText.color = new Color(0.1f, 0.3f, 0.4f);
            canvasText.text = "Everyone who steps into this scene" + "\n" + "Enjoy ur summer vacation!!!";
        }

        else
        {
            canvasText.text = null;
            hintText.text = null;
        }
    }
}
