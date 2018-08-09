using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1B : MonoBehaviour {
    public GameObject Stage1Script;
    public GameObject Stage1C;
    public GameObject Stage2;
    public GameObject Stage1StartButton;

    public void Stage1Start()
    {
        Stage1Script.SetActive(true);
        Stage2.SetActive(false);
        Stage1C.SetActive(true);
        Stage1StartButton.SetActive(true);

    }

    public void Stage1Cancel() {
        Stage1Script.SetActive(false);
        Stage2.SetActive(true);
        Stage1C.SetActive(false);
        Stage1StartButton.SetActive(false);

    }
    // Use this for initialization
    void Start () {
        Stage1Script.SetActive(false);
        Stage1C.SetActive(false);
        Stage1StartButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
