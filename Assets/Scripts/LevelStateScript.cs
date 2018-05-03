using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD

public class LevelStateScript : MonoBehaviour {
	public startScore startScore;
	public static LevelStateScript instance;
	public Canvas canvas;
=======
using UnityEngine.EventSystems;
using System;
using TMPro;

public class LevelStateScript : MonoBehaviour {
	public static LevelStateScript instance;
	public GameObject canvas;
>>>>>>> dupe-of-dupe
	public Question currentQ;
	public Dictionary<string, Question> qDict;
    private Dictionary<string, bool> visitedSceneList;
    private string currentScene;
<<<<<<< HEAD
    
	// Use this for initialization
	void Awake() {
		this.InstanceControl();
		populateDict();
        Scene scene = SceneManager.GetActiveScene();
        visitedSceneList = new Dictionary<string, bool>();
        currentScene = scene.name;
        visitedSceneList.Add(currentScene,true);
        SceneManager.sceneLoaded += addSceneToVisited;

    }
	private void InstanceControl(){
        Debug.Log("instance:"+(instance == this).ToString());
		if(instance == null) {
=======
    private float camX = 0.0f;
    private float camY = 0.0f;
    Ray ray;
    int badClicks;
    
	void Awake() {
		
        if(instance == null)
        {
            Debug.Log("wtfdontrunme");
            populateDict();
            Scene scene = SceneManager.GetActiveScene();
            visitedSceneList = new Dictionary<string, bool>();
            currentScene = scene.name;
            visitedSceneList.Add(currentScene, true);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            SceneManager.sceneLoaded += updatedScene;
        }
        InstanceControl();
    }

	private void InstanceControl(){
		if(instance == null) {
            Debug.Log("amIrunnin?");
>>>>>>> dupe-of-dupe
			instance = this;
			DontDestroyOnLoad(this);
		}
		else if(this != instance){
<<<<<<< HEAD
			Destroy(this.gameObject);
=======
            DestroyImmediate(this.gameObject);
>>>>>>> dupe-of-dupe
		}
	}

    private void populateDict()
    {
        qDict = LabQuestions.import();
<<<<<<< HEAD
        Debug.Log("test");
    }
    public void updateQ(string id) {
        Debug.Log(id);
		currentQ = qDict[id];
=======
    }

    public void updateQ(string id) {
		currentQ = qDict[id];
        currentQ.foundIt();
>>>>>>> dupe-of-dupe
		updateCanvas();
	}

	public void answerClicked(string ans) {
<<<<<<< HEAD
=======
        Debug.Log("clicked!");
>>>>>>> dupe-of-dupe
		if(!(ans == currentQ.currSelected())){
			currentQ.setSelected(ans);
		}
		else {
			currentQ.setSelected(null);
		}
<<<<<<< HEAD
		updateCanvas();
	}

	public void updateCanvas(){
        //code to set canvas elements for current question
        Debug.Log(canvas.transform.GetChild(0).GetType());
        Transform panel = canvas.transform.GetChild(0);
        //set question text
        panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        //set answer text
        //a
        panel.transform.Find("A").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.aText;
        if(currentQ.currSelected() == "A") {
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else{
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
=======
        updateCanvas();
    }

	public void updateCanvas(){
        Transform panel = canvas.transform.GetChild(0);
        panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        panel.transform.Find("A").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.aText;
        //a
        if(currentQ.currSelected() == "A") {
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else{
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
>>>>>>> dupe-of-dupe
        }
        //b
        panel.transform.Find("B").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.bText;
        if (currentQ.currSelected() == "B")
        {
<<<<<<< HEAD
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
=======
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
>>>>>>> dupe-of-dupe
        }
        //c
        panel.transform.Find("C").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.cText;
        if (currentQ.currSelected() == "C")
        {
<<<<<<< HEAD
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
=======
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        }
        else
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().GetComponent<UnityEngine.UI.Image>().color = Color.white;
>>>>>>> dupe-of-dupe
        }
        //d
        panel.transform.Find("D").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.dText;
        if (currentQ.currSelected() == "D")
        {
<<<<<<< HEAD
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else
        {
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
        }
        //string a = panel.GetComponent<UnityEngine.UI.Text>().text;
        //panel.GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        //Debug.Log(a);
    }

	public void finalJudgement(){
		if (currentQ.selectedIsCorrect ()) {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 5);
		} else {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - 1);
		}
		Debug.Log ("Score = " + PlayerPrefs.GetInt ("Score"));
	}
    public void addSceneToVisited(Scene loadedScene, LoadSceneMode mode)
=======
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
        int score = scoreCalc();
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        Debug.Log(score);

        
        GameObject.Find("Summary").GetComponent<TextMeshProUGUI>().text = "You found " +numFound() +" safety infractions out of "+numQs()+".You correctly identified why " +numCorrect()+ " of those " +numFound()+ " safety infractions were unsafe.";
    }

    private int numQs()
    {
        return qDict.Count;
    }

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

    private int numWrong()
    {
        int numWrong = 0;
        foreach (KeyValuePair<string, Question> q in qDict)
        {
            if (q.Value.selectedIsWrong())
            {
                numWrong++;
            }
        }
        return numWrong;
    }
    private int numMissed()
    {
        int numMissed = 0;
        foreach (KeyValuePair<string, Question> q in qDict)
        {
            if(!q.Value.foundBool())
            {
                numMissed++;
            }
        }
        return numMissed;
    }


    private int scoreCalc()
    {
        int score = 0;
        //    correct             found        chose wrong    missedq          clicked safe
        score = 5 * numCorrect() + 5 * numFound() - numWrong() - numMissed() - badClicks;
        Debug.Log("nt: " +numQs());
        Debug.Log("nc: " +numCorrect());
        Debug.Log("nf: " +numFound());
        Debug.Log("nw: " +numWrong());
        Debug.Log("nm: " +numMissed());
        Debug.Log("bc: " +badClicks);
        return score;
    }

    public void addSceneToVisited()
>>>>>>> dupe-of-dupe
    {
        string name = SceneManager.GetActiveScene().name;
        if (!visitedSceneList.ContainsKey(name))
        {
            visitedSceneList.Add(name, true);
        }
<<<<<<< HEAD
        Debug.Log(name);
    }
=======

    }

>>>>>>> dupe-of-dupe
    public Dictionary<string, bool>.KeyCollection getScenes()
    {
        return visitedSceneList.Keys;
    }
<<<<<<< HEAD
    public bool queryScenesDict(string scene)
    {
        return visitedSceneList[scene];
    }

    void Start () {
		//canvas = GameObject.FindWithTag("Menu").GetComponent<Canvas>();
        //DontDestroyOnLoad(canvas);
        Debug.Log(GameObject.FindWithTag("Menu").GetComponent<Canvas>().ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
=======

    public bool queryScenesDict(string scene)
    {
        bool tmp;
        try
        {
            tmp = visitedSceneList[scene];
        }
        catch
        {
            tmp = false;
        }
        return tmp;
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
>>>>>>> dupe-of-dupe

}