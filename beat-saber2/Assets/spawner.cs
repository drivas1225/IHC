using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = 0.1f;// (60 / 130);
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string s = FindObjectOfType<AudioManager>().GetClipName("music");
        if (timer > beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0,4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }

        if (s == "TheFatRat - Unity")
            timer += Time.deltaTime;
        else if (s == "Undertale - Megalovania")
            timer += Time.deltaTime * 4;
        else
            timer += Time.deltaTime * 2;
       
    }
}
