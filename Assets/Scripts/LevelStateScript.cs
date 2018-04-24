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
    private float camX = 0.0f;
    private float camY = 0.0f;
    
	// Use this for initialization
	void Awake() {
		this.InstanceControl();
		populateDict();
        Scene scene = SceneManager.GetActiveScene();
        visitedSceneList = new Dictionary<string, bool>();
        currentScene = scene.name;
        visitedSceneList.Add(currentScene,true);
        SceneManager.sceneLoaded += updatedScene;

    }

	private void InstanceControl(){
        //Debug.Log("instance:"+(instance == this).ToString());
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
        //Debug.Log("test");
    }

    public void updateQ(string id) {
        //Debug.Log(id);
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
        //Debug.Log(canvas.transform.GetChild(0).GetType());
        Transform panel = canvas.transform.GetChild(0);
        //set question text
        panel.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = currentQ.qText;
        //set answer text
        //a
        panel.transform.Find("A").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.aText;

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
        setCameraOrientation();
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

    public void setCameraOrientation()
    {
        //Debug.Log("pre");
        //GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(new Vector3(90, 0, 30));
        //Debug.Log("post");
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
		//canvas = GameObject.FindWithTag("Menu").GetComponent<Canvas>();
        //DontDestroyOnLoad(canvas);
        //Debug.Log(GameObject.FindWithTag("Menu").GetComponent<Canvas>().ToString());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}