using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemUse : MonoBehaviour
{

    public GameObject itemInInven;

    public GameObject ladderGet;
    public GameObject ladderSet;
    public GameObject ladderPut;

    bool isItem1, isItem2, isItem3;

    // Use this for initialization
    void Start()
    {


        isItem1 = isItem2 = isItem3 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isItem1)
        {

            if (Input.GetKey(KeyCode.Z))
            {
                ladderGet.SetActive(false);
                itemInInven.SetActive(true);
            }
        }

        if (isItem2)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ladderSet.SetActive(!(ladderSet.activeSelf));
                itemInInven.SetActive(!itemInInven.activeSelf);
            }
        }

        if (isItem3)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                if (itemInInven.activeSelf)
                {
                    ladderPut.SetActive(true);
                    itemInInven.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "item1")
            isItem1 = true;
        if (collision.gameObject.name == "item2")
            isItem2 = true;
        if (collision.gameObject.name == "item3")
            isItem3 = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "item1")
            isItem1 = false;
        if (collision.gameObject.name == "item2")
            isItem2 = false;
        if (collision.gameObject.name == "item3")
            isItem3 = false;


    }
}