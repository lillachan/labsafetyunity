using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStateScript : MonoBehaviour {
	//public startScore startScore;
	public static LevelStateScript instance;
	public Canvas canvas;
	public Question currentQ;
	public Dictionary<string, Question> qDict;
    private Dictionary<string, bool> visitedSceneList;
    private string currentScene;
    
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
        Debug.Log("test");
    }
    public void updateQ(string id) {
        Debug.Log(id);
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
        //code to set canvas elements for current question
        Debug.Log(canvas.transform.GetChild(0).GetType());
        Transform panel = canvas.transform.GetChild(0);
        //set question text
        panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        //set answer text
        //a
        panel.transform.Find("A").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.aText;

        if(currentQ.currSelected() == "A") {
            var colors = panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(200, 200, 200);
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        else{
            var colors = panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(255, 255, 255);
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        //b
        panel.transform.Find("B").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.bText;
        if (currentQ.currSelected() == "B")
        {
            var colors = panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(200, 200, 200);
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        else
        {
            var colors = panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(255, 255, 255);
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        //c
        panel.transform.Find("C").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.cText;
        if (currentQ.currSelected() == "C")
        {
            var colors = panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(200, 200, 200);
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        else
        {
            var colors = panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(255, 255, 255);
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        //d
        panel.transform.Find("D").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.dText;
        if (currentQ.currSelected() == "D")
        {
            var colors = panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(200, 200, 200);
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        else
        {
            var colors = panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().colors;
            colors.normalColor = new Color(255, 255, 255);
            panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().colors = colors;
        }
        //string a = panel.GetComponent<UnityEngine.UI.Text>().text;
        //panel.GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        //Debug.Log(a);
    }

    public void addSceneToVisited(Scene loadedScene, LoadSceneMode mode)
    {
        string name = SceneManager.GetActiveScene().name;
        if (!visitedSceneList.ContainsKey(name))
        {
            visitedSceneList.Add(name, true);
        }

        Dictionary<string, bool>.KeyCollection
                //Debug.Log(name);
                vr = getScenes();
        foreach (string str in vr)
        {
            print("list: "+str);
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

    void Start () {
		//canvas = GameObject.FindWithTag("Menu").GetComponent<Canvas>();
        //DontDestroyOnLoad(canvas);
        Debug.Log(GameObject.FindWithTag("Menu").GetComponent<Canvas>().ToString());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}