using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primaryAttack : MonoBehaviour
{
    private PlayerData data;
    private Player_Effects_Controller effects_Controller;
    private PlayerInput input;
    private Rigidbody2D rb2d;
    public GameObject leftAttack;
    public GameObject rightAttack;
    public GameObject upAttack;

    private PlayerAnimatorController animatorController;
    // Start is called before the first frame update
    void Start()
    {
        DisableColliders();
        data = GetComponent<PlayerData>();
        input = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        effects_Controller = GetComponent<Player_Effects_Controller>();
        animatorController = GetComponent<PlayerAnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(input.up) && Input.GetKey(input.attack))
        {
            if (animatorController.primattackup())
            {
                upAttack.SetActive(true);
                data.playerStatus = PlayerStatus.attacking;
                StartCoroutine("disableOnIdle");
            }
        }
        if (Input.GetKey(input.attack))
        {
            if ((data.leftwall() || data.rightwall()) && !data.grounded())
            {
                if (animatorController.wallprimaryattack())
                {
                    data.playerStatus = PlayerStatus.attacking;
                    StartCoroutine("disableOnIdle");
                    if (data.facingLeft)
                    {
                        rightAttack.SetActive(true);
                    }
                    else
                    {
                        leftAttack.SetActive(true);
                    }
                }
            }
            else
            {
                if (animatorController.primattack1())
                {
                    data.playerStatus = PlayerStatus.attacking;
                    StartCoroutine("disableOnIdle");
                    if (data.facingLeft)
                    {
                        leftAttack.SetActive(true);
                    }
                    else
                    {
                        rightAttack.SetActive(true);
                    }
                }
            }

        }
    }

    IEnumerator disableOnIdle()
    {
        while (data.playerStatus == PlayerStatus.attacking)
        {
            yield return null;
        }
        DisableColliders();
    }
    public void DisableColliders()
    {
        leftAttack.SetActive(false);
        rightAttack.SetActive(false);
        upAttack.SetActive(false);
    }
}
