using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toHall3_2 : MonoBehaviour {

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

    void OnMouseDown()
    {
        SceneManager.LoadScene("Hall3_2");
    }
}
