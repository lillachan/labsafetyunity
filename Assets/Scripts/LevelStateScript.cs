using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStateScript : MonoBehaviour {
	public startScore startScore;
	public static LevelStateScript instance;
	public Canvas canvas;
	public Question currentQ;
	public Dictionary<string, Question> qDict;
	// Use this for initialization
	void Awake() {
		this.InstanceControl();
        qDict = new Dictionary<string, Question>();
		populateDict();
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
        //one line per question
        qDict.Add("fireExtinguisher", new Question(
                                "Which of the following best describes the safety infraction?",
                                "answer 1.",
                                "answer b",
                                "wrongn answer",
                                "yes",
                                "D"
        ));
        Debug.Log("test");
    }
    public void updateQ(string id) {
        Debug.Log(id);
		currentQ = qDict[id];
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
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else{
            panel.transform.Find("A").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
        }
        //b
        panel.transform.Find("B").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.bText;
        if (currentQ.currSelected() == "B")
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else
        {
            panel.transform.Find("B").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
        }
        //c
        panel.transform.Find("C").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.cText;
        if (currentQ.currSelected() == "C")
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Image>().color = new Color(200, 200, 200);
        }
        else
        {
            panel.transform.Find("C").GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255);
        }
        //d
        panel.transform.Find("D").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = currentQ.dText;
        if (currentQ.currSelected() == "D")
        {
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

	void Start () {
		//canvas = GameObject.FindWithTag("Menu").GetComponent<Canvas>();
        //DontDestroyOnLoad(canvas);
        Debug.Log(GameObject.FindWithTag("Menu").GetComponent<Canvas>().ToString());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

}

public class Question {
	public string qText;
	public string aText;
	public string bText;
	public string cText;
	public string dText;
	private string selected;
	private string correct;
	public Question(string qText, string aText, string bText, string cText, string dText, string correct){
		selected = null;
		this.qText = qText;
		this.aText = aText;
		this.bText = bText;
		this.cText = cText;
		this.dText = dText;
		this.correct = correct;
	}
	public string currSelected(){
		return selected;
	}
	public void setSelected(string choice){
		if(choice != selected){
			selected = choice;
		}
		else{
			selected = null;
		}
        Debug.Log(currSelected());
	}
	public bool selectedIsCorrect(){
		if(selected == correct){
			return true;
		}
		else{
			return false;
		}
	}
	public bool isAnswered(){
		if(selected != null){
			return true;
		}
		return false;
	}

}