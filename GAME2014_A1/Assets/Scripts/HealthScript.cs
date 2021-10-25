/*
HealthScript - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
Handles all characters taking damge and when they explode

Revision History
Oct. 24, 2021 - all code.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioClip hit;
    public float HP = 1;
    public GameObject explosion;
    public GameObject coin;
    public Transform hBar;

    // called from outside, deals damage until health is 0 and then blows up into coins in random positions nearby and removed from scene
    public void takeDamage(float damage)
    {
        hitSound.clip = hit; 
        hitSound.Play();
        HP -= damage;
        hBar.localScale = new Vector3(HP, 0.4f, 1);
        if (HP <= 0)
        {
            if (gameObject.tag == "Player")
            {
                Instantiate(explosion, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().switchTunes(3);
                SceneManager.LoadScene("Game Over");
            }
            else
            {
                Instantiate(explosion, transform.position, transform.rotation);
                int numcoins = Random.Range(0, 5);
                for (int i = 0; i < numcoins; i++)
                {
                    Vector3 randomDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                    Vector3 dropSpot = transform.position + randomDirection;
                    Instantiate(coin, dropSpot, transform.rotation);
                }
                GameObject.FindGameObjectWithTag("scoreKeep").GetComponent<Score>().addScore(20);
                Destroy(gameObject);
            }
        }
    }
}
