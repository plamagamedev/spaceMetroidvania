using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageamount;
    public int force;
    public void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.layer==Layer.playerLayer){
            other.GetComponent<PlayerStats>().Damage(damageamount,this.gameObject,force,true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
