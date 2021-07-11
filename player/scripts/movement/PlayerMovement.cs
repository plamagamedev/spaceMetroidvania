using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData data;
    private Player_Effects_Controller effects_Controller;
    private PlayerInput input;
    private Rigidbody2D rb2d;

    public float speed;
    public float airControl;
    public float jumpTime;
    public float walljumpTime;
    public float maxJumpTime;
    public float jumpForce;
    public float wallXforce;
    public float wallYforce;
    public float gravityfall;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<PlayerData>();
        input = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        effects_Controller = GetComponent<Player_Effects_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(input.left) && !Input.GetKey(input.right))
        {
            data.moving = false;
        }

        //left side movement
        if (Input.GetKey(input.left))
        {
            if (!data.moving)
            {
                data.moving = true;
                rb2d.AddForce(new Vector2(-speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }

            data.facingLeft = true;
            if (data.grounded())
            {
                rb2d.AddForce(new Vector2(-speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                rb2d.AddForce(new Vector2(-airControl, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        //roght side movement
        if (Input.GetKey(input.right))
        {
            if (!data.moving)
            {
                data.moving = true;
                rb2d.AddForce(new Vector2(speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
            data.facingLeft = false;
            if (data.grounded())
            {
                rb2d.AddForce(new Vector2(speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                rb2d.AddForce(new Vector2(airControl, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
        //fast slow
        if (!data.moving && data.detector_Data.grounded && !Input.GetKey(input.jump) && rb2d.velocity.y > -.1f && rb2d.velocity.y < .1f)
        {
            rb2d.velocity = rb2d.velocity * .7f;
        }
        //jump
        if (Input.GetKeyDown(input.jump))
        {
            //Ground JUMP
            if (walljumpTime <= 0 && jumpTime <= 0 && data.grounded())
            {
                jumpTime = maxJumpTime;
                effects_Controller.Jump();
            }
            //walljump            
            if (jumpTime <= 0 && walljumpTime <= 0 && data.wallJump && (data.leftwall() || data.rightwall()))
            {
                walljumpTime = .1f;
                if (data.leftwall())
                {
                    if (data.detector_Data.toptopleft)
                    {
                        rb2d.AddForce(new Vector2(wallXforce, wallYforce), ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(wallXforce / 2, wallYforce), ForceMode2D.Impulse);
                    }

                    effects_Controller.JumpWall(data.leftPos.transform, false);
                }
                else
                {
                    if (data.detector_Data.toptopright)
                    {
                        rb2d.AddForce(new Vector2(-wallXforce, wallYforce), ForceMode2D.Impulse);
                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(-wallXforce / 2, wallYforce), ForceMode2D.Impulse);
                    }

                    effects_Controller.JumpWall(data.rightPos.transform, true);
                }
            }
        }
        //normal jump
        if (Input.GetKey(input.jump))
        {
            if (jumpTime > 0)
            {
                effects_Controller.jumpAfter();
                rb2d.AddForce(new Vector2(0, jumpForce) * Time.deltaTime, ForceMode2D.Impulse);
                jumpTime -= Time.deltaTime;
            }
            if (walljumpTime > 0)
            {
                walljumpTime -= Time.deltaTime;
            }
        }
        else
        {
            jumpTime = 0;
            if (walljumpTime > 0)
            {
                walljumpTime -= Time.deltaTime;
            }
        }
        //GRavity control
        if (rb2d.velocity.y > 0)
        {
            rb2d.gravityScale = 1;
        }
        else
        {
            if (data.leftwall() || data.rightwall())
            {
                if (!data.wallJump || Input.GetKey(input.down) || (!data.detector_Data.topleft && !data.detector_Data.topright))
                {
                    rb2d.gravityScale = 2;
                }
                else
                {
                    rb2d.gravityScale = 0;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                }
            }
            else if (rb2d.velocity.y < -5)
            {
                rb2d.gravityScale = gravityfall;
            }
            else
            {
                rb2d.gravityScale = gravityfall * .8f;
            }

        }
        data.Yspeed = rb2d.velocity.y;
        data.Xspeed = rb2d.velocity.x;
    }
}
