using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = 5f;
    private Animator anim;
    private SpriteRenderer sprite;
    private float x = 0f;

    private enum MoveState {idle, run, jump, fall}

    private BoxCollider2D boxCol;
    [SerializeField] private LayerMask jumpGround;
    [SerializeField] AudioSource jumpSound;

    [SerializeField] private float doubleJump = 5.5f;
    private bool canDoubleJump;
    private bool canFlip;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {

        x = Input.GetAxisRaw("Horizontal"); //raw for immediate stop
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) ) {
            if(IsGrounded())
            {
                rb.velocity = new Vector2 (rb.velocity.x, 10f);
                jumpSound.Play();
                canDoubleJump = true;
            }
            else {
                if (Input.GetKeyDown(KeyCode.Space) ) {
                    if(canDoubleJump) {
                        rb.velocity = new Vector2 (rb.velocity.x, doubleJump);
                        jumpSound.Play();
                        canDoubleJump = false;
                        anim.SetBool("DoubleJump", true);
                    }
                }
            }
            
        }
        if(IsGrounded()) {
            anim.SetBool("DoubleJump", false);
        }

        AnimState();
        
    }

    private void AnimState() {
        MoveState state;

        //running to the right
        if (x > 0f) {
            //anim.SetBool("run", true);
            state =  MoveState.run;
            //sprite.flipX = false;//flip right
            if(canFlip == true) {
                transform.Rotate(0f,180f,0f);
                canFlip = false;
            }
            
        }
        //running to the left
        else if (x < 0f) {
            //anim.SetBool("run", true);
            state =  MoveState.run;
            //sprite.flipX = true; //flip left
            if(canFlip == false) {
                transform.Rotate(0f,180f,0f);
                canFlip = true;
            }

        }

        //stopping
        else {
            //nim.SetBool("run", false);
            state =  MoveState.idle;
        }

        //jump
        if (rb.velocity.y > 0.1f) {
            state =  MoveState.jump;
        }

        //fall
        if (rb.velocity.y < -0.1f) {
            state =  MoveState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
