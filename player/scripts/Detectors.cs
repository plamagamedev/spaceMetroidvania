using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectors : MonoBehaviour
{
    private PlayerData data;
    public LayerMask whatisGround;
    public Vector2 size;
    public float Range;
    public GameObject groundDetect;
    public GameObject leftDetect;
    public GameObject rightDetect;

    // Start is called before the first frame update
    void Start(){
        data=GetComponentInParent<PlayerData>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapBox(groundDetect.transform.position,size,0,whatisGround)){
            data.grounded=true;
        }else{
            data.grounded=false;
        }
        if (Physics2D.OverlapCircle(leftDetect.transform.position,Range,whatisGround)){
            data.leftWall=true;
        }else{
            data.leftWall=false;
        }
        if (Physics2D.OverlapCircle(rightDetect.transform.position,Range,whatisGround)){
            data.rightWall=true;
        }else{
            data.rightWall=false;
        }
    }
    public void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawCube(groundDetect.transform.position, size);
        Gizmos.color = new Color(0, 1, 0, 0.75F);
        Gizmos.DrawSphere(leftDetect.transform.position, Range);
        Gizmos.DrawSphere(rightDetect.transform.position, Range);
    }
}
