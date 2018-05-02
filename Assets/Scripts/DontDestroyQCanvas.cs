using UnityEngine;

public class DontDestroyQCanvas : MonoBehaviour {

    public static DontDestroyQCanvas instance;

    void Awake()
    {
        this.InstanceControl();
    }
    private void InstanceControl()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(this.gameObject);
        }
    }

    void Start () {
    }
    public void addListeners(LevelStateScript lvl)
    {
        Transform panel = this.transform.GetChild(0);
        panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { lvl.answerClicked("A"); });
        panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { lvl.answerClicked("B"); });
        panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { lvl.answerClicked("C"); });
        panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { lvl.answerClicked("D"); });
    }
	
	void Update () {
		
	}
}
