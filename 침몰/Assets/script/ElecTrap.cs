using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTrap : MonoBehaviour {
    private playerMove player;
    private Lever lever;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.DealDamage(player.MaxHealth);
        }
        

    }

    // Update is called once per frame
    void Update () {
        
	}
}
