using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

    float jumppower = 5f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;

    public int speed;
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

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

        isJumping = false;
    }
}
