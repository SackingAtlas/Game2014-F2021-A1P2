/*
ButtonScript - GAME2014-A1P2-[100753770]
Harrison Black, 100753770
Last modified - Oct. 24, 2021 
button logic that also effects persistant sounds/transition sounds

Revision History
Oct. 24, 2021 - all code.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private void Start()
    {
       // source = GetComponent<AudioSource>();
    }
    public void Play()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().playSound();
        GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().switchTunes(2);
        SceneManager.LoadScene("Game1");
    }

    public void Learn()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().playSound();
        SceneManager.LoadScene("Instructions");
    }
    public void Menu()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().playSound();
        GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().switchTunes(1);
        SceneManager.LoadScene("Menu");
    }
    //public void GameOver()
    //{
    //    GameObject.FindGameObjectWithTag("Audio").GetComponent<soundScript>().switchTunes(3);
    //    SceneManager.LoadScene("Game Over");
    //}
}