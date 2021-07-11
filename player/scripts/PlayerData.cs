using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool control=true;
    public PlayerStatus playerStatus;
    public Detector_Data detector_Data;
    public GameObject feetPos;
    public GameObject leftPos;
    public GameObject rightPos;
    public float Yspeed;
    public float Xspeed;
    public bool moving;
    public bool direction;
    public bool facingLeft;
    public bool wallJump;

    public bool leftwall()
    {
        return (detector_Data.left || detector_Data.topleft);
    }
    public bool rightwall()
    {
        return (detector_Data.right || detector_Data.topright);
    }
    public bool grounded()
    {
        return detector_Data.grounded;
    }
    public IEnumerator yieldControl(float time){
        control=false;
        yield return new WaitForSeconds(time);
        control=true;
    }
    public bool bottom(){
        return detector_Data.bottomleft&&detector_Data.bottomright&&detector_Data.grounded;
    }
}
public enum PlayerStatus{
    idle,attacking,
}