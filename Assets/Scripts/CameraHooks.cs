using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraHooks : MonoBehaviour {
    GameObject camera;
	// Use this for initialization
	void Start () {
        SceneManager.sceneLoaded += getNewCamera;
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(onClick);
        camera = GameObject.FindWithTag("MainCamera");
    }

    private void onClick()
    {
        camera.GetComponent<Mouselook>().enabled = true;
        camera.GetComponent<Mouselook>().EnableMouse();

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void getNewCamera(Scene loadedScene, LoadSceneMode mode)
    {
        camera = GameObject.FindWithTag("MainCamera");
    }
    
}
