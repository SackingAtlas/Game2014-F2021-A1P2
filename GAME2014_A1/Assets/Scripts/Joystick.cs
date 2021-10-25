/*
Joystick - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
Most of player funtion with thumbstick movement 

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Camera cam;
    public Transform stick;
    public Transform cannon;
    public Transform firepoint;
    private Vector2 stickStartPos;
    private Vector2 currentStickPos;
    public Transform player;
    public float speed = 1.0f;
    public float maxSpeed;
    public float rotSpeed = 10.0f;
    private float timeTouchBegan;
    public GameObject Bullet;
    public Animator anim;
    public AudioSource engine;
    public AudioSource sounds;
    public AudioClip idleEng;
    public AudioClip moveEng;
    public AudioClip Cannon;
    public AudioClip coin;
    private int currsound = 0;

    private void Start()
    {
        stickStartPos = stick.position;
        engine.Play();
        GameObject.FindGameObjectWithTag("scoreKeep").GetComponent<Score>().resetScore();
    }
    private void Update()
    {
        currentStickPos = stick.position;
        Move();
        camFollow();
    }

    //fire a bullet where you tap on screen
    private void fire(Vector3 worldTouch)
    {
        cannon.transform.LookAt(worldTouch, Vector3.forward);
        sounds.clip = Cannon;
        sounds.Play();
        Instantiate(Bullet, firepoint.position, firepoint.rotation);
    }
    private void Move()
    {
        foreach (Touch touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position); //specify z ????
            worldTouch = new Vector3(worldTouch.x, worldTouch.y, -10);
            //figures out if you are tapping or holding
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                timeTouchBegan = Time.time;

            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //if you are tapping then fire and send where you tapped on screen
                float tapTime = Time.time - timeTouchBegan;
                if (tapTime <= 0.2f)
                {
                    fire(worldTouch);
                }
            }
        }
        Vector2 stickPos = currentStickPos - stickStartPos;
        Vector2 direction = Vector2.ClampMagnitude(stickPos, 1.0f); // restrains the stick position to feed back a range of -1 to 1 by clamping radius
        if (direction.x != 0 && direction.y != 0)//if you are moving, set all sounds and animation to match
        {
            anim.SetBool("moving", true);
            soundBoard(2);
            
            player.Translate(Vector3.up * speed * Time.deltaTime); //move forward 
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);//rotate until you match the thumbstick direction
        }
        else
        {
            anim.SetBool("moving", false);
            soundBoard(1);
        }
    }
    //changeing engine sounds depending on if moving or not without restarting over and over
    private void soundBoard(int sound)
    {
        if (sound != currsound)
        {
            currsound = sound;
            if (sound == 1)
            {
                engine.clip = idleEng;
                engine.Play();
            }
            if (sound == 2)
            {
                engine.clip = moveEng;
                engine.Play();
            }
        }
    }

    //keep camera with tank
        private void camFollow()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    //coin pick up 
    public void gotCoin()
    {
        sounds.clip = coin;
        sounds.Play();
    }
}
