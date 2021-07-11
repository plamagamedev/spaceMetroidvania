using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private Detector_Data Detector_Data;
    public LayerMask whatisGround;
    public Vector2 size;
    public float Range;
    public GameObject groundDetect;
    public GameObject leftDetect;
    public GameObject rightDetect;

    public GameObject toprightCornerDetect;
    public GameObject toptoprightCornerDetect;

    public GameObject topleftCornerDetect;
    public GameObject toptopleftCornerDetect;
    public GameObject bottomleft;
    public GameObject bottomRight;
    // Start is called before the first frame update
    void Start()
    {
        Detector_Data = GetComponentInParent<Detector_Data>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(groundDetect.transform.position, size, 0, whatisGround))
        {
            Detector_Data.grounded = true;
        }
        else
        {
            Detector_Data.grounded = false;
        }
        if (Physics2D.OverlapCircle(leftDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.left = true;
        }
        else
        {
            Detector_Data.left = false;
        }
        if (Physics2D.OverlapCircle(rightDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.right = true;
        }
        else
        {
            Detector_Data.right = false;
        }
        if (Physics2D.OverlapCircle(toprightCornerDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.topright = true;
        }
        else
        {
            Detector_Data.topright = false;
        }
        if (Physics2D.OverlapCircle(topleftCornerDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.topleft = true;
        }
        else
        {
            Detector_Data.topleft = false;
        }
        if (Physics2D.OverlapCircle(toptoprightCornerDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.toptopright = true;
        }
        else
        {
            Detector_Data.toptopright = false;
        }
        if (Physics2D.OverlapCircle(toptopleftCornerDetect.transform.position, Range, whatisGround))
        {
            Detector_Data.toptopleft = true;
        }
        else
        {
            Detector_Data.toptopleft = false;
        }
        //bottom
        if (Physics2D.OverlapCircle(bottomleft.transform.position, Range, whatisGround))
        {
            Detector_Data.bottomleft = true;
        }
        else
        {
            Detector_Data.bottomleft = false;
        }
        if (Physics2D.OverlapCircle(bottomRight.transform.position, Range, whatisGround))
        {
            Detector_Data.bottomright = true;
        }
        else
        {
            Detector_Data.bottomright = false;
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawCube(groundDetect.transform.position, size);
        Gizmos.color = new Color(0, 1, 0, 0.75F);
        Gizmos.DrawSphere(leftDetect.transform.position, Range);
        Gizmos.DrawSphere(rightDetect.transform.position, Range);
        Gizmos.color = new Color(0, .75f, .1f, 0.75F);
        Gizmos.DrawSphere(toprightCornerDetect.transform.position, Range);
        Gizmos.DrawSphere(toptoprightCornerDetect.transform.position, Range);
        Gizmos.DrawSphere(topleftCornerDetect.transform.position, Range);
        Gizmos.DrawSphere(toptopleftCornerDetect.transform.position, Range);
        Gizmos.DrawSphere(bottomleft.transform.position, Range);
        Gizmos.DrawSphere(bottomRight.transform.position, Range);
    }
}
