﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class LevelStateScript : MonoBehaviour {
	public static LevelStateScript instance;

	public GameObject canvas;
	public Question currentQ;
	public Dictionary<string, Question> qDict;
    private Dictionary<string, bool> visitedSceneList;
    private string currentScene;
    private float camX = 0.0f;
    private float camY = 0.0f;
    Ray ray;
    int badClicks;
    
	void Awake() {
		this.InstanceControl();
		populateDict();
        Scene scene = SceneManager.GetActiveScene();
        visitedSceneList = new Dictionary<string, bool>();
        currentScene = scene.name;
        visitedSceneList.Add(currentScene,true);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        SceneManager.sceneLoaded += updatedScene;
    }

	private void InstanceControl(){
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		}
		else if(this != instance){
			Destroy(this.gameObject);
		}
	}

    private void populateDict()
    {
        qDict = LabQuestions.import();
    }

    public void updateQ(string id) {
		currentQ = qDict[id];
        currentQ.foundIt();
		updateCanvas();
	}

	public void answerClicked(string ans) {
        Debug.Log("clicked!");
		if(!(ans == currentQ.currSelected())){
			currentQ.setSelected(ans);
		}
		else {
			currentQ.setSelected(null);
		}
        updateCanvas();
    }

	public void updateCanvas(){
        Debug.Log("udc");
        Transform panel = canvas.transform.GetChild(0);
        panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        panel.transform.Find("A").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.aText;
        //a
        if(currentQ.currSelected() == "A") {
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else{
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        //b
        panel.transform.Find("B").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.bText;
        if (currentQ.currSelected() == "B")
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        //c
        panel.transform.Find("C").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.cText;
        if (currentQ.currSelected() == "C")
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
        //d
        panel.transform.Find("D").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.dText;
        if (currentQ.currSelected() == "D")
        {
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else
        {
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }
    }

    public void updatedScene(Scene scene, LoadSceneMode mode)
    {
        addSceneToVisited();
        if (SceneManager.GetActiveScene().name == "FinalScene")
        {
            setScore();
            Destroy(instance.gameObject);
        }
    }

    private void setScore()
    {
        Debug.Log(GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Score: "+scoreCalc());

        //Added Summary
        GameObject.Find("Summary").GetComponent<TextMeshProUGUI>().text = "You found " +numFound() +" safety infractions out of 13.You correctly identified why " +numCorrect()+ " of those " +numFound()+ " safety infractions were unsafe.";
    }

    //for summary
    private int numFound()
    {
        int numFound = 0;
        foreach(KeyValuePair<string, Question> q in qDict)
        {
            if (q.Value.foundBool())
            {
                numFound++;
            }
        }
        return numFound;
    }
    //for summary
    private int numCorrect()
    {
        int numCorrect = 0;
                foreach(KeyValuePair<string, Question> q in qDict)
        {
            if (q.Value.selectedIsCorrect())
            {
                numCorrect++;
            }
        }
        return numCorrect;
    }

    private int scoreCalc()
    {
        int score = 0;
        int numqs = qDict.Count;
        int numCorrect =0;
        int numFound= 0;
        int numWrong = 0;
        foreach(KeyValuePair<string, Question> q in qDict)
        {
            if (q.Value.foundBool())
            {
                numFound++;
            }
            if (q.Value.selectedIsWrong())
            {
                numWrong++;
            }
            if (q.Value.selectedIsCorrect())
            {
                numCorrect++;
            }

        }
        //    correct             found        chose wrong    missedq          clicked safe
        score = numCorrect * 5 + numFound * 5 - numWrong - (numqs - numFound) - badClicks;
        return score;
    }

    public void addSceneToVisited()
    {
        string name = SceneManager.GetActiveScene().name;
        if (!visitedSceneList.ContainsKey(name))
        {
            visitedSceneList.Add(name, true);
        }

    }

    public Dictionary<string, bool>.KeyCollection getScenes()
    {
        return visitedSceneList.Keys;
    }

    public bool queryScenesDict(string scene)
    {
        return visitedSceneList[scene];
    }

    public void saveCamera(float x, float y)
    {
        camX = x;
        camY = y;
    }
    public float getX()
    {
        return camX;
    }
    public float getY()
    {
        return camY;
    }

    void Start () {
        if (this.canvas == null)
        {
            Debug.Log("runnint");
            foreach (Canvas c in Resources.FindObjectsOfTypeAll<Canvas>())
            {
                Debug.Log(c.name);
                if (c.name == "QCanvas")
                {
                    canvas = c.gameObject;
                    break;
                }
            }
        }
        else
        {
            Debug.Log(canvas.ToString());
        }
        canvas.GetComponent<DontDestroyQCanvas>().addListeners(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !(canvas.GetComponent<Canvas>().isActiveAndEnabled))
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("object clicked!");
            }
            else
            {
                badClicks++;
                Debug.Log("count: "+badClicks);
            }
        }

    }

}