using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerAnimatorController animatorController;
    public GameObject respawn;
    public PlayerData playerData;
    private Rigidbody2D rb2d;
    public int health;
    public int maxhealth;
    public bool invincible;
    public bool dead;
    //TODO
    public int resurect;
    public float invincibilityTime;

    void Start()
    {
        health = maxhealth;
        animatorController = GetComponent<PlayerAnimatorController>();
        rb2d = GetComponent<Rigidbody2D>();
        respawn = new GameObject("respawn");
        playerData = GetComponent<PlayerData>();
        invincible = false;

    }
    public void Update()
    {
        if (playerData.bottom()&&!invincible)
        {
            if (!Physics2D.OverlapCircle(playerData.feetPos.transform.position,3,Layer.damageLayer)){
                respawn.transform.position = transform.position;
            }
        }
    }
    // Update is called once per frame

    public void Damage(int damageamount, GameObject damage, int force, bool disable)
    {
        if (!invincible)
        {
            StartCoroutine("invincibilitytime");
            health -= damageamount;
            if (health <= 0)
            {
                //animatorController.Die();
                dead = true;
            }
            else
            {
                rb2d.velocity=Vector2.zero;
                rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                if (transform.position.x < damage.transform.position.x)
                {
                    rb2d.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
                }
                else
                {
                    rb2d.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
                }
            }
        }
    }
    public void DamageRespawn(int damageamount, GameObject damage, int force, bool disable)
    {
        if (!invincible)
        {
            StartCoroutine("invincibilitytime");
            StartCoroutine("respawnaftertime");
            health -= damageamount;
            if (health <= 0)
            {
                //animatorController.Die();
                dead = true;
            }
            else
            {
                rb2d.velocity=Vector2.zero;
                rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
    }
    public IEnumerator invincibilitytime()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
        public IEnumerator respawnaftertime()
    {
        yield return new WaitForSeconds(invincibilityTime/2);
        transform.position=respawn.transform.position;
    }
}
