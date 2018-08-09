﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {

    float jumppower = 5f;
    public float swimming_gravity = -0.005f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
    bool inLadder = false;
    bool onStair = false;
    bool inWater = false;
    bool inElevator = false;
    public bool nowJumping = false;

    public float CurrentHealth;
    public float MaxHealth;

    public float CurrentPoison;//Poison bar
    public float MaxPoison;

    public float CurrentOxygen;//Oxygen bar
    public float MaxOxygen;


    public Slider Healthbar;
    public Slider Poisonbar;
    public Slider Oxygenbar;


    public bool rockCollide = false;//rock

    public int speed;
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        CurrentHealth = MaxHealth;
        Healthbar.value = CalculateHealth();


        CurrentOxygen = MaxOxygen;
        Oxygenbar.value = CalculateOxygen();


        CurrentPoison = 0.001f;
        Poisonbar.value = CalculatePoison();
    }
	
	// Update is called once per frame
	void Update () {

        if ( !onStair && !inWater)
        {
            LRMove();

        }
        //사다리
       if(inLadder)
        {
            rigid.gravityScale = 0;

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime*4 );
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime * 4);
            }
        }
       //계단
        if (onStair)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime*3);
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if (inWater)
        {
            swimming();
            rigid.gravityScale = swimming_gravity;
        }

        isJumping = false;
        if (Input.GetButtonDown("Jump") && !nowJumping)
        {
            isJumping = true;
        }
        if (inElevator)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime );
        }
        Jump();
       

    }

    void LRMove()
    {
        //방향키로 플레이어 움직이기
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void swimming()
    {
        LRMove();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime/2);

        }

    }

    void Jump()
    {
        if (!isJumping) return;

        

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumppower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ladder")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            inLadder = true;
            this.transform.localPosition = new Vector2(16087, this.transform.localPosition.y);
        }
        if (collision.tag == "stair")
            onStair = true;
        if (collision.tag == "water")
        {
            inWater = true;
            //swimming();

        }
        if (collision.tag == "elevator")
        {
            inElevator = true;
            rigid.gravityScale = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        nowJumping = false;
        if (collision.gameObject.name == "elevator_top")
            speed = 0;
    }

    /*
    isJumping =
    inLadder = 
    onStair = f
    inWater = f
    inElevator
    */

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(!(isJumping && inLadder && inWater && inElevator))
            nowJumping = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ladder")
        {
            inLadder = false;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        if (collision.tag == "stair")
            onStair = false;
        if (collision.tag == "water")
            inWater = false;

        rigid.gravityScale = 1;
        
    }

    float CalculateHealth()//hp
    {
        return CurrentHealth / MaxHealth;

    }

    float CalculateOxygen()
    {
        return CurrentOxygen / MaxOxygen;
    }

    float CalculatePoison()
    {
        return CurrentPoison / MaxPoison;
    }

    public void DealDamage(float damageValue)//healthdamage
    {

        CurrentHealth -= damageValue;
        Healthbar.value = CalculateHealth();

        if (CurrentHealth <= 0)
            Die();
    }

    public void DealOxygen(float damageValue)//Oxygendamage
    {

        CurrentOxygen -= damageValue;
        Oxygenbar.value = CalculateOxygen();

        if (CurrentOxygen <= 0)
            Die();
    }

    public void DealPoison(float poisonValue)//Poisondamage
    {
        CurrentPoison += poisonValue;
        Poisonbar.value = CalculatePoison();

        if (CurrentPoison >= MaxPoison)
            Die();
    }

    void Die()//die
    {
        CurrentHealth = 0;
        CurrentPoison = MaxPoison;
        Debug.Log("You dead.");
    }

}
