using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerData data;
    public bool control = true;
    private const string idle = "IDLE";
    private const string run = "RUN";
    private const string up = "UP";
    private const string down = "DOWN";
    private const string fall = "FALL";

    void Start()
    {
        animator = GetComponent<Animator>();
        data = GetComponent<PlayerData>();
    }
    public void Update()
    {
        if (control)
        {
            if (data.grounded)
            {
                if (data.moving)
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
                if (data.Yspeed > 0)
                {
                    playUp();
                }
                else
                {
                    playDown();
                }
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
    IEnumerator OnCompleteFall()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            yield return null;

        // TODO: Do something when animation did complete
    }
    private void PlayAnimation(string animation)
    {
        animator.Play(animation, 0);
    }
}
