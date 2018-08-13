using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{

    private Player player;
    Rigidbody2D rb;

    // Use this for initialization
<<<<<<< HEAD
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMove>();
=======
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094
        rb = GetComponent<Rigidbody2D>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
            rb.isKinematic = false;



    }
    void OnCollisionEnter2D(Collision2D rock)
    {
<<<<<<< HEAD
        if (rock.gameObject.name.Equals("player"))
        {
            player.DealDamage(5);
            Destroy(gameObject);
        }

        if (rock.gameObject.name.Equals("b1f_stair") || rock.gameObject.name.Equals("b1f_first"))
        {
            Destroy(gameObject);
        }


        //if (rock.CompareTag("Untagged") {


=======
        if (rock.gameObject.name.Equals("Player")) {
            player.DealDamage(5);
            Destroy(gameObject);
        }
        /*
        if (rock.CompareTag("Untagged")) {
           
        }*/
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094
    }


    // Update is called once per frame
    void Update()
    {

    }


}
