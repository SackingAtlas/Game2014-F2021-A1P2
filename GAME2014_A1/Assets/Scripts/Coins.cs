/*
Coins - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
Coin pick up sounds and collision

Revision History
Oct. 24, 2021 - all code.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //coin hit, add to score and remove from scene.
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Joystick>().gotCoin();
        GameObject.FindGameObjectWithTag("scoreKeep").GetComponent<Score>().addScore(5);
        Destroy(gameObject);
    }
}
