using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {

    private bool sceneVisited;
    private string currentScene;
    private string imageName;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        imageName = GetComponent<Image>().name;
        sceneVisited = GameObject.FindWithTag("GameController").GetComponent<LevelStateScript>().queryScenesDict(imageName);
        GetComponent<Image>().color = Color.black;
        //Debug.Log("our current image is" + imageName);
    }

    // Update map to correct colors
    void Update()
    {
        if (currentScene.Equals(imageName))
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (sceneVisited)
        {
            GetComponent<Image>().color = Color.blue;
        }
    }
}
