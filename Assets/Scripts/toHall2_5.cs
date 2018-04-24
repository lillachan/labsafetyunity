using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toHall2_5 : MonoBehaviour {

    public Material arrow;
    public Material hilighted;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = hilighted;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = arrow;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton()
    {
        float x = GameObject.FindWithTag("MainCamera").transform.eulerAngles.x;
        float y = GameObject.FindWithTag("MainCamera").transform.eulerAngles.y;
        GameObject.FindWithTag("GameController").GetComponent<LevelStateScript>().saveCamera(x, y);
        SceneManager.LoadScene("Hall2_5");
    }
}
