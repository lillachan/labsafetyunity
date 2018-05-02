using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

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
        if(canvas == null)
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
		if(!(ans == currentQ.currSelected())){
			currentQ.setSelected(ans);
		}
		else {
			currentQ.setSelected(null);
		}
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
            Destroy(this.gameObject);
        }
    }

    private void setScore()
    {
        throw new NotImplementedException();
    }

    public void addSceneToVisited()
    {
        string name = SceneManager.GetActiveScene().name;
        if (!visitedSceneList.ContainsKey(name))
        {
            visitedSceneList.Add(name, true);
        }

        Dictionary<string, bool>.KeyCollection vr = getScenes();
        foreach (string str in vr)
        {
            //Debug.Log("list: "+str);
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