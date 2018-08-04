using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {


    private Player player;
    public GameObject electrap;
    private int countkey = 0;

    public bool LeverDown = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerStay2D(Collider2D lever)
    {
        if (Input.GetKeyDown(KeyCode.Z))
            countkey++;

        if (lever.CompareTag("Player")&& countkey==1)
        {
            LeverDown = true;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (LeverDown == true)
        {
            Destroy(electrap);
        }
    }
}
