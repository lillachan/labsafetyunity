using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainHall4 : MonoBehaviour {
<<<<<<< HEAD

=======
    public GameObject UI;
>>>>>>> dupe-of-dupe
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

<<<<<<< HEAD
    void OnMouseDown()
    {
        SceneManager.LoadScene("Mainhall_4");
=======
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
            SceneManager.LoadScene("Mainhall_4");
        }
        
>>>>>>> dupe-of-dupe
    }
}
