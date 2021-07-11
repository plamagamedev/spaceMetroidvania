using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParent : MonoBehaviour
{
    public int damage;
    public GameObject hiteffect;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<DamageChild>().damage = damage;
            child.gameObject.GetComponent<DamageChild>().hiteffect = hiteffect;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
