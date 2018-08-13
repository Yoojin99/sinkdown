using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target.gameObject != null) {
            targetPosition.Set(target.transform.position.x, target.transform.position.y+0.5f, this.transform.position.z);

            this.transform.position = targetPosition;
        }
		
	}
}
