using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainHall10 : MonoBehaviour {
    public GameObject UI;
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
        if (UI == null)
        {
            foreach (Canvas c in Resources.FindObjectsOfTypeAll<Canvas>())
            {
                if (c.name == "QCanvas")
                {
                    UI = c.gameObject;
                    break;
                }
            }
        }
        if (UI.activeSelf == false)
        {
            float x = GameObject.FindWithTag("MainCamera").transform.eulerAngles.x;
            float y = GameObject.FindWithTag("MainCamera").transform.eulerAngles.y;
            GameObject.FindWithTag("GameController").GetComponent<LevelStateScript>().saveCamera(x, y);
            SceneManager.LoadScene("Mainhall_10");
        }
            
    }
}
