using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{

    private Player player;

    private int countkey = 0;

    public static int playerrescued = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    void OnTriggerStay2D(Collider2D poisonarea)
    {

        if (Input.GetKeyDown(KeyCode.Z))
            countkey++;

        if (poisonarea.CompareTag("Player")&&countkey==3)
        {
            Destroy(gameObject);
            playerrescued = 1;
            
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        

    }
}
