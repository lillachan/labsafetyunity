using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {
	public startScore startScore;
	public GameObject UI;
	public Text text;
    public GameObject controller;
    public string id;

	// Use this for initialization
	void Start () {
		UI = GameObject.FindWithTag("Menu");
        controller = GameObject.FindWithTag("GameController");
        
		UI.SetActive (false);
		if (UI != null) {
			text = UI.GetComponent<Text> ();
			Debug.Log (text);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp() {
        //transform.localScale += new Vector3(0.1F, 0, 0);
        //UI.SetActive(!UI.activeInHierarchy);
        controller.GetComponent<LevelStateScript>().updateQ(id);
        UI.SetActive(true);
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score")+5);
		Debug.Log ("Score = " + PlayerPrefs.GetInt ("Score"));
	}
}
