using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {

	public GameObject UI;
	public Text text;

	public GameObject cam;

	// Use this for initialization
	void Start () {
		UI = GameObject.FindWithTag ("Menu");
		UI.SetActive (false);
		if (UI != null) {
			text = UI.GetComponent<Text> ();
			Debug.Log (text);
		}
		cam = GameObject.FindWithTag ("MainCamera");
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
	}
}
