using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class spawner : NetworkBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = 0.1f;// (60 / 130);
    private float timer;
    private float timer_delay;
    public GameObject gameover;
    public GameObject explotion;

    bool is_over = false;

    // Start is called before the first frame update
    void Start()
    {
        timer_delay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Sound x = FindObjectOfType<AudioManager>().GetAudio("music");
        if (!x.source.isPlaying)
        {
            timer_delay += Time.deltaTime;
            if (timer_delay > 1.5)
            {
                Debug.Log("fin del juego!");
                if (!is_over)
                {
                    is_over = true;
                    GameObject displayGameOver = Instantiate(gameover);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
        }
        else
        {
            string s = FindObjectOfType<AudioManager>().GetClipName("music");

            if (timer > beat)
            {
                CmdSpawn();
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

    [Command]
    void CmdSpawn()
    {
        GameObject cube = Instantiate(cubes[Random.Range(0, 4)], points[Random.Range(0, 4)]);
        cube.transform.localPosition = Vector3.zero;
        cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
        NetworkServer.Spawn(cube);
    }
}
