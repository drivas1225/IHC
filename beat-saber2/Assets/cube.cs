using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class cube : MonoBehaviour
{
    //AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        //aud = GetComponent<AudioSource>();
        //Debug.Log(aud.name);
    }

    // Update is called once per frame
    void Update()
    {
        string s = FindObjectOfType<AudioManager>().GetClipName("music");
        if (s == "TheFatRat - Unity")
        {
            Debug.Log("Easy Game");
            transform.position += Time.deltaTime * transform.forward * 20;
        }
        else if(s == "Undertale - Megalovania")
        {
            Debug.Log("Hard Game");
            transform.position += Time.deltaTime * transform.forward * 40;
        }
        else
        {
            Debug.Log("Normal Game");
            transform.position += Time.deltaTime * transform.forward * 30;
        }
    }
}
