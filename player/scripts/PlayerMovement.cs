using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData data;
    private PlayerInput input;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprd;
    public float speed;
    public float jumpTime;
    public float maxJumpTime;
    public float jumpForce;
    public float gravityfall;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<PlayerData>();
        input = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        sprd=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        data.moving=false;
        if (Input.GetKey(input.left))
        {
            sprd.flipX=true;
            data.moving=true;
            rb2d.AddForce(new Vector2(-speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Input.GetKey(input.right))
        {
            sprd.flipX=false;
            data.moving=true;
            rb2d.AddForce(new Vector2(speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
        }
        if (Input.GetKey(input.jump))
        {
            if (data.grounded)
            {
                jumpTime = maxJumpTime;
            }
            if (jumpTime > 0)
            {
                rb2d.AddForce(new Vector2(0, jumpForce) * Time.deltaTime, ForceMode2D.Impulse);
                jumpTime -= Time.deltaTime;
            }
        }
        else
        {
            jumpTime = 0;
        }
        if (rb2d.velocity.y>0){
            rb2d.gravityScale=1;
        }else{
            rb2d.gravityScale=gravityfall;
        }
        data.Yspeed=rb2d.velocity.y;
    }
}
