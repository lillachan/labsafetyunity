using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyQCanvas : MonoBehaviour {

    public static DontDestroyQCanvas instance;
    // Use this for initialization
    void Awake()
    {
        this.InstanceControl();
    }
    private void InstanceControl()
    {
        //Debug.Log("instance:" + (instance == this).ToString());
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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
