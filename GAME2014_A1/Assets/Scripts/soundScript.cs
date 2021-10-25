/*
soundScript - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
built for handling persistant music and sounds bewteen trasitions

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class soundScript : MonoBehaviour
{
    public AudioSource music;
    public AudioSource buttonSound;
    public AudioClip menu;
    public AudioClip game;
    public AudioClip gOver;

    private void Start()
    {
        //prevent duplicates so sounds dont layer, if more than 1 of these destroy this one
        DontDestroyOnLoad(transform.gameObject);
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Audio");
        if (clones.Length != 1)
            Destroy(this.gameObject);

        playBG();
    }

    //change the song that is playing
    public void switchTunes(int tune)
    {
        if (tune == 1)
        {
            music.clip = menu;
            playBG();
        }
        if (tune == 2)
        {
            music.clip = game;
            playBG();
        }
        if (tune == 3)
        {
            music.clip = gOver;
            playBG();
        }

    }

    //play music
    public void playBG()
    {
        if (music.isPlaying) return;
        music.Play();
    }

    //play soundFX
    public void playSound()
    {
        if (buttonSound.isPlaying) return;
        buttonSound.Play();
    }

    //stop music
    public void pause()
    {
        music.Stop();
    }
}