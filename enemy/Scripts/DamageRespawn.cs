using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRespawn : MonoBehaviour
{
    public int damageamount;
    public int force;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == Layer.playerLayer)
        {
            other.GetComponent<PlayerStats>().DamageRespawn(damageamount, this.gameObject, force, true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
