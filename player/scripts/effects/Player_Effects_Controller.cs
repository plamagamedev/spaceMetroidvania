using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Effects_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jumpEffect;
    public float jumpAfterEffectdelay;
    public float timeAfterEffectdelay;
    public GameObject jumpAfterEffect;
        public GameObject jumpWallEffect;
    private PlayerData data;
    void Start()
    {
        data = GetComponent<PlayerData>();
    }
    void Update()
    {
        timeAfterEffectdelay -= Time.deltaTime;
        //timejumpdelay-=Time.deltaTime;
    }
    public void Jump()
    {
        Instantiate(jumpEffect, data.feetPos.transform.position, Quaternion.identity);
    }
        public void JumpWall(Transform position,bool left)
    {

        GameObject gameObject= Instantiate(jumpWallEffect, position.position, Quaternion.identity);
        if (left){
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
    }
    public void jumpAfter()
    {
        if (timeAfterEffectdelay <= 0)
        {
            Instantiate(jumpAfterEffect, data.feetPos.transform.position, Quaternion.identity);
            timeAfterEffectdelay = jumpAfterEffectdelay;
        }

    }
}
