using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = 5f;
    private Animator anim;
    private SpriteRenderer sprite;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal"); //raw for immediate stop
        rb.velocity = new Vector2(x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new Vector2 (rb.velocity.x, 10f);
        }

        //running to the right
        if (x > 0f) {
            anim.SetBool("run", true);
            sprite.flipX = false;//flip right
        }
        //running to the left
        else if (x < 0f) {
            anim.SetBool("run", true);
            sprite.flipX = true; //flip left
        }

        //stopping
        else {
            anim.SetBool("run", false);
        }
    }
}
