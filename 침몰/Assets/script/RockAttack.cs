using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour {

    private playerMove player;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
        rb = GetComponent<Rigidbody2D>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("player"))
            rb.isKinematic = false;
        
    }
    void OnCollisionEnter2D(Collision2D rock)
    {
        if (rock.gameObject.name.Equals("player")) {
            player.DealDamage(5);
            Destroy(gameObject);
        }
        
        /*if (rock.CompareTag("Untagged")) {
        
        }*/
    }
            
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
