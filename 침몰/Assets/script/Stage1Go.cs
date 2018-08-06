using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Go : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void StartStage1() {
        Invoke("startstage1", .5f);

            }
    
    // Update is called once per frame
    void startstage1 () {
        Application.LoadLevel("Stage1Scene");
	}
}
