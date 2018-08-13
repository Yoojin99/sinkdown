using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.SceneManagement;
=======
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094

public class playerMove : MonoBehaviour {


    float jumppower = 5f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
<<<<<<< HEAD
    bool inLadder = false;
    bool onStair = false;
    bool inWater = false;
    bool inElevator = false;
    public bool nowJumping = false;
    bool inPoison = false;

    public float CurrentHealth;
    public float MaxHealth;

    public float CurrentPoison;//Poison bar
    public float MaxPoison;

    public float CurrentOxygen;//Oxygen bar
    public float MaxOxygen;


    public Slider Healthbar;
    public Slider Poisonbar;
    public Slider Oxygenbar;

    public bool RescuedMob1;
    public bool RescuedMob2;
    public bool RescuedMob3;

    public GameObject Mob1;
    public GameObject Mob2;
    public GameObject Mob3;

    public static int check = 0;
    public bool rockCollide = false;//rock
=======
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094

    public int speed;
	// Use this for initialization
	void Start () {
        RescuedMob1 = false;
        RescuedMob2 = false;
        RescuedMob3 = false;

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

<<<<<<< HEAD
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

            check=1;
        }
        if (inWater)
        {
            swimming();
            rigid.gravityScale = swimming_gravity;
            DealOxygen(1);
        }

        if (inPoison) {
            DealPoison(3);
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
=======
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094
        //방향키로 플레이어 움직이기
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.left * speed * Time.deltaTime/2);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }

        isJumping = false;
        if (Input.GetButtonDown("Jump"))
            isJumping = true;
        Jump();
       

    }

    void Jump()
    {
        if (!isJumping) return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumppower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
<<<<<<< HEAD

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "ladder")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            inLadder = true;
            
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
        if (collision.tag == "poison") {
            inPoison = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        nowJumping = false;
        if (collision.gameObject.name == "elevator_top")
        {
            speed = 0;
            
        }
    }

    /*
    isJumping =
    inLadder = 
    onStair = f
    inWater = f
    inElevator
    */
    void checkmob() {
        if (Mob1 == null)
            check = 1;//                                          체크하는 부분!!!!!
        if (Mob2 == null)
            check = 2;
        if (Mob3 == null)
            check = 3;

    }

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
        if (collision.tag == "poison")
            inPoison = false;

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
    
    public LevelSelector fuck;

    public int levelreached =1;

    public LevelControlScript script;

    void Die()//die
    {
        CurrentHealth = 0;
        CurrentPoison = MaxPoison;
        Debug.Log("You dead.");

        if (CurrentHealth == 0) {
            script.youWin();
        }

        
       
    }

    
   
    
=======

        isJumping = false;
    }
>>>>>>> e1636ce3841231d337f393af69f0ccdb88d10094
}
