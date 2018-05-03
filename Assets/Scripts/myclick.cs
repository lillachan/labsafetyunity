using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {
<<<<<<< HEAD
	public startScore startScore;
=======
	//public startScore startScore;
>>>>>>> dupe-of-dupe
	public static GameObject UI;
	public Text text;
    public static GameObject controller;
    public string id;
<<<<<<< HEAD

=======
>>>>>>> dupe-of-dupe
	public GameObject cam;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        if (UI == null) {
            UI = GameObject.FindWithTag("Menu");
            controller = GameObject.FindWithTag("GameController");
        }
=======
        if (controller == null) {
            controller = GameObject.FindWithTag("GameController");
        }
        if(UI == null)
        {
            UI = GameObject.FindWithTag("Menu");
        }
>>>>>>> dupe-of-dupe
        
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

	void OnMouseUpAsButton() {
        if(UI.activeSelf == false)
        {
            //transform.localScale += new Vector3(0.1F, 0, 0);
            //UI.SetActive(!UI.activeInHierarchy);
            controller.GetComponent<LevelStateScript>().updateQ(id);
            controller.GetComponent<LevelStateScript>().updateCanvas();
            UI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            DisableMouse();
        }
	}
	
	void DisableMouse() {
		//Component look = cam.GetComponent<Mouselook> ();
		//Component ml =

		cam.GetComponent<Mouselook>().enabled = false;
		//Camera.current.GetComponent<Mouselook>().enabled = false;
		//Component looker = 
//		cam.GetComponent<Mouselook> ().enabled = false;

		//Cursor.lockState = CursorLockMode.None;
	}
<<<<<<< HEAD

	public void CloseMenu() {
		UI.SetActive (false);
	}


	// Update is called once per frame
	void Update () {

	}

	void OnMouseUp() {
		//transform.localScale += new Vector3(0.1F, 0, 0);
		//UI.SetActive(!UI.activeInHierarchy);
		UI.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		DisableMouse ();
		
        //transform.localScale += new Vector3(0.1F, 0, 0);
        //UI.SetActive(!UI.activeInHierarchy);
        controller.GetComponent<LevelStateScript>().updateQ(id);
        UI.SetActive(true);
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score")+5);
		Debug.Log ("Score = " + PlayerPrefs.GetInt ("Score"));

	}
=======
>>>>>>> dupe-of-dupe
}
