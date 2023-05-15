using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{

    public TextMeshPro canvasText;

    private string sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "world")
        {
            canvasText.text = "Only one door to escape from this infinite world";
        }
        
        // "Level: " + (currentLevel + 1) + "\n" + 
        // "Score: " + score + "\n" + 
        // "High Score: " + HighScore;
    }
}
