/*
EnemyCont - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
Enemy detection radius and their chase and shoot funtionality with sounds

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    public Transform player;
    public Transform cannon;
    public Transform enem;
    public Transform firepoint;
    public float rotSpeed;
    public float speed;
    public float detectRadius = 40;
    public float timer = 1f;
    public GameObject Bullet;
    public AudioSource sounds;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //find where to look
        Vector2 stickPos = player.transform.position - transform.position;
        Vector2 direction = Vector2.ClampMagnitude(stickPos, 1.0f); // restrains the stick position to feed back a range of -1 to 1 by clamping radius
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        cannon.transform.rotation = Quaternion.RotateTowards(cannon.transform.rotation, toRotation, rotSpeed * Time.deltaTime);

        //if they are within your detection, then chase then, if you are too close, stop moving but keep shooting
        if (Vector2.Distance(transform.position, player.transform.position) < detectRadius)
        {
            if(Vector2.Distance(transform.position, player.transform.position) < 2)
            {
                anim.SetBool("moving", false);
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                if (timer <= 0)
                {
                    sounds.Play();
                    Instantiate(Bullet, firepoint.position, firepoint.rotation);
                    timer = 1f;
                }
            }
                else
            {
                anim.SetBool("moving", true);
                //soundBoard(2);
                enem.Translate(Vector3.up * speed * Time.deltaTime);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);

                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                if (timer <= 0)
                {
                    sounds.Play();
                    Instantiate(Bullet, firepoint.position, firepoint.rotation);
                    timer = 1f;
                }
            }
        } 
        else
            anim.SetBool("moving", false);
    }
}
