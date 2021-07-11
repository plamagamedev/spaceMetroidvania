using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageChild : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer==Layer.enemyLayer){
            other.GetComponent<EnemyStats>().Damage(damage,this.gameObject,force,false);
            this.gameObject.SetActive(false);
        }
        if(other.gameObject.layer==Layer.groundLayer){
            Instantiate(hiteffect,other.ClosestPoint(transform.position),Quaternion.identity);
        }
    }
    public GameObject hiteffect;
    public int damage;
    public int force;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
