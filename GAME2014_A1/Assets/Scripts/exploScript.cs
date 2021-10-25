/*
exploScript - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
Explosion effect after a kill/death with sound

Revision History
Oct. 24, 2021 - all code.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploScript : MonoBehaviour
{
    public AudioSource Explo;

    private void Start()
    {
        Explo.Play();
    }
    void Update()
    {
        Destroy(gameObject, 1); //expire and remove explosion after 1 second
    }
}
