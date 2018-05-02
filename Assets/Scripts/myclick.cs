using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {
	//public startScore startScore;
	public static GameObject UI;
	public Text text;
    public static GameObject controller;
    public string id;
	public GameObject cam;

	// Use this for initialization
	void Start () {
        if (controller == null) {
            controller = GameObject.FindWithTag("GameController");
        }
        if(UI == null)
        {
            UI = GameObject.FindWithTag("Menu");
        }
        
		UI.SetActive (false);
		if (UI != null) {
			text = UI.GetComponent<Text> ();
			//Debug.Log (text);
		}
        cam = GameObject.FindWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp() {
        //transform.localScale += new Vector3(0.1F, 0, 0);
        //UI.SetActive(!UI.activeInHierarchy);
        controller.GetComponent<LevelStateScript>().updateQ(id);
        UI.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		DisableMouse ();
	}
	
	void DisableMouse() {
		//Component look = cam.GetComponent<Mouselook> ();
		//Component ml =

		cam.GetComponent<Mouselook> ().enabled = false;
		//Camera.current.GetComponent<Mouselook>().enabled = false;
		//Component looker = 
//		cam.GetComponent<Mouselook> ().enabled = false;

		//Cursor.lockState = CursorLockMode.None;
	}
}
