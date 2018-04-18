﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {

	public static GameObject UI;
	public Text text;
    public static GameObject controller;
    public string id;

	// Use this for initialization
	void Start () {
        if (UI == null) {
            UI = GameObject.FindWithTag("Menu");
            controller = GameObject.FindWithTag("GameController");
        }
        
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
	}
}
