using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_on_Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == Layer.damageLayer)
        {
            Destroy(this.gameObject);
        }
    }
    public void Destroy(){
        
    }
}
