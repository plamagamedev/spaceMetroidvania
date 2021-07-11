using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprd;
    private PlayerData data;
    public bool control = true;
    private const string idle = "IDLE";
    private const string run = "RUN";
    private const string up = "UP";
    private const string down = "DOWN";
    private const string fall = "FALL";
    private const string wall = "WALL";
    private const string walloffground = "WALLOFFGROUND";
    private const string primaryattack1 = "PRIMARYATTACK1";
    private const string primaryattack2 = "PRIMARYATTACK2";
    private const string primaryattackup = "PRIMARYATTACKUP";
    private const string wallattack = "WALLPRIMARYATTACK";
    void Start()
    {
        animator = GetComponent<Animator>();
        data = GetComponent<PlayerData>();
        sprd = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        if (control)
        {
            if (data.grounded())
            {
                if (data.leftwall() && data.facingLeft)
                {
                    playWall();
                }
                else if (data.rightwall() && !data.facingLeft)
                {
                    playWall();
                }
                else if (data.moving)
                {
                    playRun();
                }
                else
                {
                    playIdle();
                }
            }
            else
            {
                if (data.Yspeed > .2f)
                {
                    playUp();
                }
                else
                {
                    if (data.leftwall() && data.facingLeft)
                    {
                        playWalloff();
                    }
                    else if (data.rightwall() && !data.facingLeft)
                    {
                        playWalloff();
                    }
                    else
                    {
                        playDown();
                    }
                }
            }
            if (data.leftwall())
            {
                sprd.flipX = true;
            }
            else if (data.rightwall())
            {
                sprd.flipX = false;
            }
            else if (data.Xspeed > .1f)
            {
                sprd.flipX = false;
            }
            else if (data.Xspeed < -.1f)
            {
                sprd.flipX = true;
            }
        }
    }
    public void playIdle()
    {
        PlayAnimation(idle);
    }
    public void playRun()
    {
        PlayAnimation(run);
    }
    public void playUp()
    {
        PlayAnimation(up);
    }
    public void playDown()
    {
        PlayAnimation(down);
    }
    public void playWall()
    {
        PlayAnimation(wall);
    }
    public void playWalloff()
    {
        PlayAnimation(walloffground);
    }

    public bool primattack1()
    {
        if (control)
        {
            PlayAnimation(primaryattack1);
            control = false;
            StartCoroutine("controlOnCoplete");
            return true;
        }
        return false;
    }
    public bool primattackup()
    {
        if (control)
        {
            PlayAnimation(primaryattackup);
            control = false;
            StartCoroutine("controlOnCoplete");
            return true;
        }
        return false;
    }
    public bool primattack2()
    {
        if (control)
        {
            PlayAnimation(primaryattack2);
            control = false;
            StartCoroutine("controlOnCoplete");
            return true;
        }
        return false;
    }
    public bool wallprimaryattack()
    {
        if (control)
        {
            PlayAnimation(wallattack);
            control = false;
            StartCoroutine("controlOnCoplete");
            return true;
        }
        return false;
    }
    IEnumerator controlOnCoplete()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;
        data.playerStatus = PlayerStatus.idle;
        control = true;
        // TODO: Do something when animation did complete
    }
    private void PlayAnimation(string animation)
    {
        animator.Play(animation, 0);
    }
}
