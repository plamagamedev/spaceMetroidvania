using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour
{
    //also add an empty frame as to not cause errors
    void Start()
    {
                 Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
    }


}
