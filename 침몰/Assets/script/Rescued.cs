using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescued : MonoBehaviour {


    public GameObject mouse;


    void enable() {
        if (playerMove.check == 1)
            Destroy(mouse);
    }


	// Use this for initialization
	void Start () {

        if (playerMove.check == 1) {
            Destroy(mouse);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
