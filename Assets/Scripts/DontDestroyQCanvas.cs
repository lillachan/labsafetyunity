<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> dupe-of-dupe

public class DontDestroyQCanvas : MonoBehaviour {

    public static DontDestroyQCanvas instance;
<<<<<<< HEAD
    // Use this for initialization
=======

>>>>>>> dupe-of-dupe
    void Awake()
    {
        this.InstanceControl();
    }
    private void InstanceControl()
    {
<<<<<<< HEAD
        Debug.Log("instance:" + (instance == this).ToString());
=======
>>>>>>> dupe-of-dupe
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

<<<<<<< HEAD
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
=======
    void Start () {
    }
    public void addListeners(LevelStateScript lvl)
    {
        Debug.Log("here");
        Transform panel = this.transform.GetChild(0);
        panel.transform.Find("A").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { lvl.answerClicked("A"); });
        panel.transform.Find("B").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { lvl.answerClicked("B"); });
        panel.transform.Find("C").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { lvl.answerClicked("C"); });
        panel.transform.Find("D").GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { lvl.answerClicked("D"); });
    }
	
>>>>>>> dupe-of-dupe
	void Update () {
		
	}
}
