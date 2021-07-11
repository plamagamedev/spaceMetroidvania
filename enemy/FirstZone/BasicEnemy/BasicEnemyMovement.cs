using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    private Detector_Data detector_;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprd;
    public EnemyStats stats;
    public bool left;
    public float speed;
    void Start()
    {
        detector_ = GetComponent<Detector_Data>();
        rb2d = GetComponent<Rigidbody2D>();
        sprd = GetComponent<SpriteRenderer>();
        stats = GetComponent<EnemyStats>();
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.dead)
        {
            if (left)
            {
                if (detector_.right || !detector_.bottomright)
                {
                    left = false;
                    sprd.flipX = left;
                }
                rb2d.AddForce(new Vector2(speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                if (detector_.left || !detector_.bottomleft)
                {
                    left = true;
                    sprd.flipX = left;
                }
                rb2d.AddForce(new Vector2(-speed, 0) * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

    }
}
