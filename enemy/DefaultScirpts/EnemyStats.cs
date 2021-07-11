using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public GeneralEnemyAnimatorController animatorController;
    public Rigidbody2D rb2d;
    public bool dead = false;
    public int maxhealth;
    public int health;
    public void Start()
    {
        health = maxhealth;
        animatorController = GetComponent<GeneralEnemyAnimatorController>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
    }
    public void Damage(int damageamount, GameObject damage, int force, bool disable)
    {
        health -= damageamount;
        if (health <= 0)
        {
            animatorController.Die();
            dead = true;
        }
        else
        {
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
