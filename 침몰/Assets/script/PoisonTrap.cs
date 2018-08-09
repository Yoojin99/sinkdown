using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : MonoBehaviour {

    private playerMove player;
    Rigidbody2D rb;

    public GameObject poisontrap;
    public float SpawningTime = 2;
    float nextSpawnTime;
    Vector2 pos;
    

	// Use this for initialization
	void Start () {
        pos = this.gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
        rb = GetComponent<Rigidbody2D>();
    }
    //&& Time.time>nextSpawnTime
    // Update is called once per frame
    void Update () {
        nextSpawnTime = Time.time + SpawningTime;
	}
    void OnTriggerEnter2D(Collider2D poison)
    {
        if (poison.CompareTag("Player"))
        {
            player.DealPoison(20);
        }

        if (poison.CompareTag("Untagged"))
        {
            poisontrap.transform.position = pos;
            rb.isKinematic = true;
        }
    }
    

    }
