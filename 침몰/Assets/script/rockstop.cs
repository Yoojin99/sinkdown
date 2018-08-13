using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockstop : MonoBehaviour {

    Rigidbody2D rb;

    
    Vector2 pos;

    public GameObject rock;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }

    void OnCollisionEnter2D(Collision2D rock)
    {
        if (rock.gameObject.name.Equals("rockstop"))
        {
            pos = this.gameObject.transform.position;
        }

    }

    // Update is called once per frame
    void Update () {
        
    }
}
