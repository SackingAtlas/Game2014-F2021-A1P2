/*
bulletLogic - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
bullet movement, collision and expiration

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    public float moveSpeed = 5;
    public HealthScript healthScript;
    void Update()
    {
        //movement forward on the angle its shot from
        //transform.up * moveSpeed * Time.deltaTime;
        transform.position += transform.up * Time.deltaTime * moveSpeed;
        Destroy(gameObject, 3);
    }

    //if we hit somthing then give it damage and destroy bullet
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<HealthScript>().takeDamage(0.5f);
        Destroy(gameObject);
    }
}
